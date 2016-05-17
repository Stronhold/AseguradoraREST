using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Aseguradora
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicePolicy
    {
        /// <summary>
        /// Returns the data for a specified Policy
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [OperationContract]
        Policy GetData(int id);

        // TODO: agregue aquí sus operaciones de servicio
        [OperationContract]
        Policy[] GetAllPolicies();

        [OperationContract]
        int[] GetAllID();

        [OperationContract]
        bool AddPolicy(int id, string name, string desc, string type);

        [OperationContract]
        bool RemovePolicy(int id);

        [OperationContract]
        bool UpdatePolicy(int id, string name, string desc,string type);
    }

    // Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
    // Puede agregar archivos XSD al proyecto. Después de compilar el proyecto, puede usar directamente los tipos de datos definidos aquí, con el espacio de nombres "Aseguradora.ContractType".
    [DataContract]
    public class Policy
    {
        string name= "";
        string description = "";
        int id = 0;
        string type = "";

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public Policy()
        {

        }
        
        public Policy(string n, string d, int i, string type)
        {
            Name = n;
            Description = d;
            ID = i;
            Type = type;
        }
    }
}
