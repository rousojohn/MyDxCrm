using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var collection = crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]);
            return await collection.DeleteOneAsync(filter);
        }

        public void InsertOne<T> (T obj)
        {
            crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]).InsertOne(obj);
            
        }
    
        public async Task<ReplaceOneResult> UpdateOneAsync<T> (FilterDefinition<T> filter, T update) {
            var collection = crmDb.GetCollection<T>(mapObjectType2MongoDocs[typeof(T)]);
            return await collection.ReplaceOneAsync(filter, update); 
        }


    }
}
