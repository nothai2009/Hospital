using MongoDB.Bson;

namespace ScanDocument
{
    internal class Entity
    {
        //class get set data from DB
        public ObjectId _id { get; set; }

        public string JOB_ID { get; set; }
        public string DEPT_ID { get; set; }       //ชื่อคนสแกน
        public ObjectId FID { get; set; }
        public string HIDE { get; set; }
        public string TYPE_DOC { get; set; }

        public ObjectId files_id { get; set; }
    }
}