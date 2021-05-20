using Integration_Project.Models;
using Integration_Project.Models.MUUID.Receive;
using Integration_Project.Models.MUUID.Send;
using Integration_Project.Services.MUUIDService.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Integration_Project.Services.MUUIDService {
    public class MUUIDService : IMUUIDService {

        private readonly IConfiguration _config;

        public MUUIDService(IConfiguration config) {
            _config = config;
        }

        public Guid InsertIntoMUUID(MUUIDSend sendModel) {
            using (var context = new ReceiverContextMUUID()) {
                var response = context.MUUIDS.FromSqlRaw("SELECT UUID()");
                return response.FirstOrDefault().MUUID;
            }
        }

        public Guid GetUUID() {
            /// TODO: Nog extra toevoegen dat backup conn.string ook wordt toegepast
            string constring = _config.GetConnectionString("MUUIDConnection");
            string sql = "SELECT UUID()";
            string uuid = "";
            try {
                using (MySqlConnection connection = new MySqlConnection(constring)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, connection)) {
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                uuid = reader.GetString(0);
                            }
                        }
                    }
                    connection.Close();
                    return Guid.Parse(uuid);
                }
            } catch (Exception ex) {
                Console.WriteLine("Error retrieving muuid, please check connection or service");
                return Guid.Empty;
            }
        }
    }
}
