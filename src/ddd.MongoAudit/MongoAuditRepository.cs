using System.Collections.Generic;
using System.Linq;
using ddd.Core.Entities;
using ddd.Core.Persistence;
using ddd.Core.Providers;
using MongoDB.Driver;

namespace ddd.MongoAudit
{
    public class MongoAuditRepository<T> : IAuditRepository<T> where T : Entity
    {

        private readonly ITimeProvider _timeProvider;
        private readonly ISerializationProvider _serializationProvider;
        private readonly IMongoCollection<Audit> _collection;

        public MongoAuditRepository(string connectionString,
            ITimeProvider timeProvider,
            ISerializationProvider serializationProvider)
        {
            _timeProvider = timeProvider;
            _serializationProvider = serializationProvider;

            // Create a MongoClient object by using the connection string
            var client = new MongoClient(connectionString);

            //Use the MongoClient to access the server
            var database = client.GetDatabase("test");

            //get mongodb collection
            _collection = database.GetCollection<Audit>("auditentries");
        }

        public void Delete(IUser user, IEnumerable<T> entities)
        {
            if (user == null || entities == null) return;
            AuditEnumerable(user, entities, AuditActionType.Delete);
        }

        public void Update(IUser user, IEnumerable<T> entities)
        {
            if (user == null || entities == null) return;
            AuditEnumerable(user, entities, AuditActionType.Update);
        }

        public void Insert(IUser user, T entity)
        {
            if (user == null || entity == null) return;
            AuditSingle(user, entity, AuditActionType.Insert);
        }


        #region private methods
        private void AuditSingle(IUser user, T entity, AuditActionType auditActionType)
        {
            var a = Audit.Create(entity, user, _timeProvider.UtcNowUnix, auditActionType, _serializationProvider);
            _collection.InsertOneAsync(a);
        }

        private void AuditEnumerable(IUser user, IEnumerable<T> entities, AuditActionType auditActionType)
        {
            var a = entities.Select(
                entity => Audit.Create(entity, user, _timeProvider.UtcNowUnix, auditActionType, _serializationProvider)
                );
            _collection.InsertManyAsync(a);
        }
        #endregion
    }
}