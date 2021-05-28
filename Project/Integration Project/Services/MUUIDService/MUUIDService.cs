﻿using Integration_Project.Models;
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

        private readonly IConfiguration _config;

        public MUUIDService(IConfiguration config) {
            _config = config;
        }

        public void InsertIntoMUUID(MUUIDSend sendModel) {
            string constring = _config.GetConnectionString("MUUIDConnection");
            string sql =
                $"INSERT INTO master ( UUID, Source_EntityId, EntityType, Source) VALUES(" +
                $"UUID_TO_BIN('{sendModel.Uuid}')," +
                $"'{sendModel.Source_EntityId}'," +
                $"'{sendModel.EntityType}'," +
                $"'{sendModel.Source}');";
            try {
                using (MySqlConnection connection = new MySqlConnection(constring)) {
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
            string constring = _config.GetConnectionString("MUUIDConnection");
            string sql = $"SELECT * FROM master WHERE UUID = UUID_TO_BIN('{uuid}');";
            MUUIDReceive receivedModal = new MUUIDReceive();
            try {
                using (MySqlConnection connection = new MySqlConnection(constring)) {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(sql, connection)) {
                        using (MySqlDataReader reader = command.ExecuteReader()) {
                            while (reader.Read()) {
                                receivedModal.Uuid = new Guid((byte[])reader.GetValue(1));
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
