using System;
using System.Collections.Generic;
using System.Text;
using WIN.BILANCIO.DomainLayer;
using WIN.TECHNICAL.MIDDLEWARE.XmlSerializzation;

namespace WIN.BILANCIO.DataAccess
{
    public class UpdateFileMapper
    {
        public NodeUpdateList LoadUpdateFileByPath(string path)
        {
            return ObjectXMLSerializer<NodeUpdateList>.Load(path);
        }
    }
}
