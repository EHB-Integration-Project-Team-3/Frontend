using Integration_Project.Models;
using Integration_Project.Models.Enums;
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

        private readonly string conString = "server=10.3.17.63;database=masteruuid;port=3306;user=muuid;password=muuid";
        public void InsertIntoMUUID(MUUIDSend sendModel) {
            string sql =
                $"INSERT INTO master ( UUID, Source_EntityId, EntityType, Source) VALUES(" +
                $"UUID_TO_BIN('{sendModel.Uuid}')," +
                $"'{sendModel.Source_EntityId}'," +
                $"'{sendModel.EntityType}'," +
                $"'{sendModel.Source}');";
            try {
                using (MySqlConnection connection = new MySqlConnection(conString)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, connection)) {
                        using (MySqlDataReader reader = command.ExecuteReader()) {

                        }
                    }
                    connection.Close();
                }
            } catch (Exception ex) {
                Console.WriteLine("Error inserting model in muuid, please check connection or service");
            }
        }

        public MUUIDReceive Get(Guid uuid) {
            string sql = $"SELECT * FROM master WHERE UUID = UUID_TO_BIN('{uuid}');";
            MUUIDReceive receivedModal = new MUUIDReceive();
            try {
                using (MySqlConnection connection = new MySqlConnection(conString)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, connection)) {
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                receivedModal.Uuid = new Guid((byte[]) reader.GetValue(1));
                                receivedModal.Source_EntityId = (string) reader.GetValue(2);
                                receivedModal.EntityType = (string) reader.GetValue(3);
                                receivedModal.EntityVersion = (int) reader.GetValue(4);
                                receivedModal.Source = (string) reader.GetValue(5);
                            }
                        }
                    }
                    connection.Close();
                    return receivedModal;
                }
            } catch (Exception ex) {
                Console.WriteLine("Error retrieving muuid, please check connection or service");
                return null;
            }
        }

        public bool UpdateEntityVersion(MUUIDSend sendModal, int currentEntityVersion) {
            string sql = $"update master set EntityVersion = {currentEntityVersion} " +
                $"where Source = '{sendModal.Source}' and EntityVersion = {currentEntityVersion} - 1 and UUID = UUID_TO_BIN('{sendModal.Uuid}') and " +
                $"(select EntityVersion from master where Source = 'Canvas') < {currentEntityVersion} and " +
                $"(select EntityVersion from master where Source = 'PLANNING') < {currentEntityVersion};";
            try {
                using (MySqlConnection connection = new MySqlConnection(conString)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, connection)) {
                        command.ExecuteReader();
                    }
                    connection.Close();
                    return true;
                }
            } catch (Exception ex) {
                Console.WriteLine("Error updating model in muuid database");
                return false;
            }
        }

        public Guid GetUUID() {
            /// TODO: Nog extra toevoegen dat backup conn.string ook wordt toegepast
            string sql = "SELECT UUID()";
            string uuid = "";
            try {
                using (MySqlConnection connection = new MySqlConnection(conString)) {
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
