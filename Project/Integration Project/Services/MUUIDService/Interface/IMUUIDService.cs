using Integration_Project.Models.MUUID.Send;
using Integration_Project.Services.EventService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.MUUIDService.Interface {
    public interface IMUUIDService : IBaseService {

        public Guid InsertIntoMUUID(MUUIDSend sendModel);
        public Guid GetUUID();
    }
}
