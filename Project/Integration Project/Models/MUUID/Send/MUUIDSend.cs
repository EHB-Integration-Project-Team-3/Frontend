﻿using Integration_Project.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Models.MUUID.Send {
    public class MUUIDSend {
        public int Source_EntityId { get; set; }
        public EntityType EntityType { get; set; }
        public string Source { get; set; } = "Frontend";
    }
}
