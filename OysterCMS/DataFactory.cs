using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OysterCMS
{
    public class DataFactory
    {
        private static IDataFactory mInstance = null;
        private DataFactory()
        {
        }

        public static IDataFactory Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = (IDataFactory)Activator.CreateInstance("OysterCMS.Db.MongoDB", "OysterCMS.Templates.Db.MongoDB.DocumentManager").Unwrap();

                return mInstance;
            }
        }
    }
}
