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
            {typeof(OutcomeType), "outcomeTypes" },
            {typeof(Supplier), "suppliers" },
            {typeof(AccIncome), "incomes" },
            {typeof(AccOutcome), "outcomes" }
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
            return PatchItemsInList(collection.Find(filter).ToListAsync().Result.ToList());
        }

        private List<T> PatchItemsInList<T> (List<T> _list)
        {
            if (typeof(T) != typeof(AccOutcome) && 
                typeof(T) != typeof(AccIncome) &&
                typeof(T) != typeof(Member)
                )
                return _list;

            foreach(T i in _list)
            {
                if (typeof(T) == typeof(AccIncome))
                {
                    (i as AccIncome).TypeDescr = FindSync(Builders<IncomeType>.Filter.Where(t => t.Id == new ObjectId(((i as AccIncome)).Type))).FirstOrDefault().Description;
                    var member = FindSync(Builders<Member>.Filter.Where(t => t.Id == new ObjectId((i as AccIncome).Member))).FirstOrDefault();
                    (i as AccIncome).MemberName = string.Format("{0} {1}", member.Surname, member.Name);
                }
                else  if (typeof(T) == typeof(AccOutcome))
                {
                    (i as AccOutcome).TypeDescr = FindSync(Builders<OutcomeType>.Filter.Where(t => t.Id == new ObjectId(((i as AccOutcome)).Type))).FirstOrDefault().Description;
                    var supplier = FindSync(Builders<Supplier>.Filter.Where(t => t.Id == new ObjectId((i as AccOutcome).Supplier))).FirstOrDefault();
                    (i as AccOutcome).SupplierName = string.Format("{0} {1}", supplier.Surname, supplier.Name);
                }
                else if (typeof(T) == typeof(Member))
                {
                    (i as Member).MemberName = string.Format("{0} {1}", (i as Member).Surname, (i as Member).Name);
                }
            }

            return _list;
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
                }
                return await collection.BulkWriteAsync(models, null, cnclToken.Token);
            }
        }
    }
}
