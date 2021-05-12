using Integration_Project.Models.MUUID.Send;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.MUUIDService.Interface {
    public interface IMUUIDService {

        public Guid InsertIntoMUUID(MUUIDSend sendModel);
        public object GetUUID();
    }
}
