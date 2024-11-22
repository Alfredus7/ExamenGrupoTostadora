using System.Net;
using System.Runtime.Serialization;

namespace ExamenGrupoTostadora.WebApiClients
{
    [DataContract]
    public class Error
    {
        [DataMember]
        public bool HasError;
        [DataMember]
        public int Code;
        [DataMember]
        public string Name;
        [DataMember]
        public string Message;

    }
}
