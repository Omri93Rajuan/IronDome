namespace IrooDome.DAL
//מחלקה לניהול הנתונים של החברים שלי
{
    public class Data
    {
        //מחרוזת חיבור למסד נתונים
        string ConnectionString = "" +
            //השרת אליו מתחבר
            "server = OMRIRAJUAN\\SQLEXPRESS;" +
            //שם הדאטא בייס ששם אנחנו רוצים להתחיל
            " initial catalog =IrooDome;" +
            //פרטי חיבור
            " user id = sa ;" +
            //סיסמת החיבור
            " password = 1234;" +
            //צורת חיבור
            " TrustServerCertificate=Yes";

        //קונסטרקטור פרטי למניעת יצירת מופעים מחוץ למחלקה
        private Data()
        {
            //יצירת מופע של שכבת הנתונים עם מחרוזת החביור
            Layer = new DataLayer(ConnectionString);
        }
        //מאפיין סטטי לשמירת מופע יחיד של המחלקה
        static Data? GetData;

        //מאפיין סטטי לקבלת שכבת הנתונים

        public static DataLayer Get
        {
            get
            {
                //יצירת מופע חדש של המחלקה אם לא קיים
                if (GetData == null)
                {
                    GetData = new Data();
                }
                //החזרת שכבת הנתונים
                return GetData.Layer;
            }
        }
        //מאפיין לשמירת שכבת הנתונים
        public DataLayer Layer { get; set; }
    }
}
