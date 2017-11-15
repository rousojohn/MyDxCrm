using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DxCrm.Classes
{
    public sealed class DbManager
    {
        private static readonly DbManager instance = new DbManager();

        private IMongoDatabase crmDb;
        private Dictionary<Type, string> mapObjectType2MongoDocs = new Dictionary<Type, string>()
        {
            {typeof(Member), "members" },
            {typeof(MemberType), "memberTypes" },
            {typeof(IncomeType), "incomeTypes" },
            {typeof(OutcomeType), "outcomeTypes" }
        };

        private DbManager()
        {
            crmDb = new MongoClient(new MongoClientSettings
            {
                Server = new MongoServerAddress(ApplicationSettings.Instance.Host, ApplicationSettings.Instance.Port),
                UseSsl = false
            }).GetDatabase(ApplicationSettings.Instance.Database);

        }

        static DbManager()
        {
            //crmDb = new MongoClient(new MongoClientSettings
            //{
            //    Server = new MongoServerAddress(ApplicationSettings.Instance.Host, ApplicationSettings.Instance.Port),
            //    UseSsl = false
            //}).GetDatabase(ApplicationSettings.Instance.Database);

        }

        public static DbManager Instance { get { return instance; } }


        public List<T> FindSync<T>(FilterDefinition<T> filter) {
            var collection = crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]);
            return collection.FindSync<T>(filter).ToList();
        }

        public List<T> FindAsync<T> (FilterDefinition<T> filter)
        {
            var collection = crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]);
            return collection.Find(filter).ToListAsync().Result.ToList();
        }


        public async Task<DeleteResult> DeleteOneAsync<T> (FilterDefinition<T> filter)
        {
            using (var cnclToken = new CancellationTokenSource(TimeSpan.FromSeconds(60)))
            {
                var collection = crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]);
                return await collection.DeleteOneAsync(filter, cnclToken.Token);
            }
        }

        public async Task<DeleteResult> DeleteManyAsync<T> (FilterDefinition<T> filter)
        {
            using (var clcToken = new CancellationTokenSource(TimeSpan.FromSeconds(60)))
            {
                var collection = crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]);
                return await collection.DeleteManyAsync(filter, clcToken.Token);
            }
        }



        public void InsertOne<T> (T obj)
        {
            crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]).InsertOne(obj);
            
        }

        public async Task InsertMany<T> (IEnumerable<T> newCollection)
        {
            using (var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(60))) {
                await crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]).InsertManyAsync(newCollection, null, timeout.Token);
            }
        }
    


        public async Task<ReplaceOneResult> UpdateOneAsync<T> (FilterDefinition<T> filter, T update) {
            using (var cnclToken = new CancellationTokenSource(TimeSpan.FromSeconds(60)))
            {
                var collection = crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]);
                return await collection.ReplaceOneAsync(filter, update, null, cnclToken.Token);
            }
        }

        public async Task<BulkWriteResult> SaveCollection<T>(FilterDefinition<T> filter, /*UpdateDefinition<T> update, */IEnumerable<T> newCollection)
        {
            using (var cnclToken = new CancellationTokenSource(TimeSpan.FromSeconds(60)))
            {
                var collection = crmDb.GetCollection<BsonDocument>(mapObjectType2MongoDocs[typeof(T)]);
                var models = new WriteModel<BsonDocument>[newCollection.Count()];
                int i = 0;
                foreach(T item in newCollection)
                {
                    var itemDoc = item.ToBsonDocument();
                    models[i++] = new ReplaceOneModel<BsonDocument>(new BsonDocument("_id", itemDoc["_id"]), itemDoc);
                    //models[i++] = new ReplaceOneModel<T>(filter, item) { IsUpsert = true };
                }
                return await collection.BulkWriteAsync(models, null, cnclToken.Token);
                //return await collection.UpdateManyAsync(filter, update, new UpdateOptions() { IsUpsert = true }, cnclToken.Token);
            }
            //var deleteResult = await DeleteManyAsync<T>(filter);
            //if (deleteResult.IsAcknowledged)
        }
    }
}
