using apiServicio.Models;
using System.Data.SqlClient;
using System.Data;
using apiServicio.Business.Contracts;

namespace apiServicio.Business.Clases
{
    public class clAlmacenRepository : IclAlmacenRepository
    {
        private readonly string connectionString;

        public clAlmacenRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("conBase");
        }

        public async Task<List<clAlmacen>> GetList()
        {
            List<clAlmacen> list = new List<clAlmacen>();
            clAlmacen al;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("SELECT * FROM clAlmacen;", con);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        al = new clAlmacen();
                        al.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                        al.NombreAlmacen = Convert.ToString(reader["NombreAlmacen"]);
                        al.IdEntidad = Convert.ToInt32(reader["IdEntidad"]);
                        al.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        al.EstadoRegistro = Convert.ToString(reader["EstadoRegistro"]);
                        list.Add(al);
                    }
                }
            }
            return list;
        }

        public async Task<clAlmacen> AgregaActualiza(clAlmacen al, string tipo)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "";

                if (tipo == "c")
                    query = "SET @IdAlmacen = (SELECT ISNULL(MAX(IdAlmacen), 0) + 1 FROM clAlmacen); " +
                            "INSERT INTO clAlmacen(NombreAlmacen, IdEntidad, FechaRegistro, EstadoRegistro) " +
                            "VALUES (@NombreAlmacen, @IdEntidad, @FechaRegistro, @EstadoRegistro);";

                if (tipo == "u")
                    query = "UPDATE clAlmacen " +
                            "SET NombreAlmacen = @NombreAlmacen, IdEntidad = @IdEntidad, " +
                            "FechaRegistro = @FechaRegistro, EstadoRegistro = @EstadoRegistro " +
                            "WHERE IdAlmacen = @IdAlmacen;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    SqlParameter idResult = new SqlParameter("@IdAlmacen", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(idResult);
                    cmd.Parameters.AddWithValue("@NombreAlmacen", al.NombreAlmacen);
                    cmd.Parameters.AddWithValue("@IdEntidad", al.IdEntidad);
                    cmd.Parameters.AddWithValue("@FechaRegistro", al.FechaRegistro);
                    cmd.Parameters.AddWithValue("@EstadoRegistro", al.EstadoRegistro);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (tipo == "c")
                        al.IdAlmacen = int.Parse(idResult.Value.ToString());
                }
            }
            return al;
        }

        public async Task<bool> Elimina(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM clAlmacen WHERE IdAlmacen = @IdAlmacen;";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdAlmacen", id);

                    await con.OpenAsync();
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    return rowsAffected > 0;
                }
            }
        }

        public async Task<clAlmacen> GetById(int idAlmacen)
        {
            clAlmacen almacen = null;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM clAlmacen WHERE IdAlmacen = @IdAlmacen";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@IdAlmacen", idAlmacen);

                    await con.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            almacen = new clAlmacen
                            {
                                IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]),
                                NombreAlmacen = Convert.ToString(reader["NombreAlmacen"]),
                                IdEntidad = Convert.ToInt32(reader["IdEntidad"]),
                                FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]),
                                EstadoRegistro = Convert.ToString(reader["EstadoRegistro"])
                            };
                        }
                    }
                }
            }

            return almacen;
        }


    }
}
