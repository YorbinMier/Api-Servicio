using apiServicio.Business.Contracts;
using apiServicio.Models;
using System.Data;
using System.Data.SqlClient;

namespace apiServicio.Business.Clases
{
    public class trnIngresoRepository : ItrnIngresoRepository
    {
        private readonly string conect;
        public trnIngresoRepository(IConfiguration _con)
        {
            conect = _con.GetConnectionString("conBase");
        }

        public async Task<List<trnIngreso>> GetList()
        {
            List<trnIngreso> list = new List<trnIngreso>();
            trnIngreso l;
            using (SqlConnection con = new SqlConnection(conect))
            {
                await con.OpenAsync();
                SqlCommand cmd = new SqlCommand("select * from trnIngreso;", con);
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        l = new trnIngreso();
                        l.IdIngreso = Convert.ToInt32(reader["IdIngreso"]);
                        l.NumeroIngreso = Convert.ToString(reader["NumeroIngreso"]);
                        l.FechaReal = Convert.ToDateTime(reader["FechaReal"]);
                        l.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                        l.ComprobantePago = Convert.ToString(reader["ComprobantePago"]);
                        l.NumeroFactura = Convert.ToString(reader["NumeroFactura"]);
                        l.NumeroPreventivo = Convert.ToString(reader["NumeroPreventivo"]);
                        l.Observacion = Convert.ToString(reader["Observacion"]);
                        l.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                        l.Total = Convert.ToDecimal(reader["Total"]);
                        l.Descuento = Convert.ToDecimal(reader["Descuento"]);
                        l.IdGrupoArticulo = Convert.ToInt32(reader["IdGrupoArticulo"]);
                        l.IdProveedor = Convert.ToInt32(reader["IdProveedor"]);
                        l.IdGestion = Convert.ToInt32(reader["IdGestion"]);
                        l.IdEntidad = Convert.ToInt32(reader["IdEntidad"]);
                        l.IdUsuarioIngreso = Convert.ToInt32(reader["IdUsuarioIngreso"]);
                        l.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                        l.IdEstadoIngreso = Convert.ToInt32(reader["IdEstadoIngreso"]);
                        l.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                        l.EstadoRegistro = Convert.ToString(reader["EstadoRegistro"]);
                        l.IdTipoDocumentoEntrega = Convert.ToInt32(reader["IdTipoDocumentoEntrega"]);
                        list.Add(l);
                    }
                }
            }
            return list;
        }

        public async Task<trnIngreso> AgregaActualiza(trnIngreso l, string t)
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                string cadena = "";

                if (t == "c")
                {
                    cadena = "SET @I = (SELECT ISNULL(MAX(IdIngreso), 0) + 1 FROM trnIngreso);" +
                             "INSERT INTO trnIngreso(" +
                             "    NumeroIngreso, FechaReal, FechaIngreso, ComprobantePago, NumeroFactura, " +
                             "    NumeroPreventivo, Observacion, SubTotal, Total, Descuento, IdGrupoArticulo, " +
                             "    IdProveedor, IdGestion, IdEntidad, IdUsuarioIngreso, IdAlmacen, " +
                             "    IdEstadoIngreso, FechaRegistro, EstadoRegistro, IdTipoDocumentoEntrega) " +
                             "VALUES(" +
                             "    @NumeroIngreso, @FechaReal, @FechaIngreso, @ComprobantePago, @NumeroFactura, " +
                             "    @NumeroPreventivo, @Observacion, @SubTotal, @Total, @Descuento, @IdGrupoArticulo, " +
                             "    @IdProveedor, @IdGestion, @IdEntidad, @IdUsuarioIngreso, @IdAlmacen, " +
                             "    @IdEstadoIngreso, @FechaRegistro, @EstadoRegistro, @IdTipoDocumentoEntrega)";
                }

                if (t == "u")
                {
                    cadena = "UPDATE trnIngreso SET " +
                             "    NumeroIngreso = @NumeroIngreso, FechaReal = @FechaReal, FechaIngreso = @FechaIngreso, " +
                             "    ComprobantePago = @ComprobantePago, NumeroFactura = @NumeroFactura, NumeroPreventivo = @NumeroPreventivo, " +
                             "    Observacion = @Observacion, SubTotal = @SubTotal, Total = @Total, Descuento = @Descuento, " +
                             "    IdGrupoArticulo = @IdGrupoArticulo, IdProveedor = @IdProveedor, IdGestion = @IdGestion, " +
                             "    IdEntidad = @IdEntidad, IdUsuarioIngreso = @IdUsuarioIngreso, IdAlmacen = @IdAlmacen, " +
                             "    IdEstadoIngreso = @IdEstadoIngreso, FechaRegistro = @FechaRegistro, EstadoRegistro = @EstadoRegistro, " +
                             "    IdTipoDocumentoEntrega = @IdTipoDocumentoEntrega WHERE IdIngreso = @IdIngreso";
                }

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    SqlParameter Result = new SqlParameter("@I", SqlDbType.Int) { Direction = ParameterDirection.Output };
                    cmd.Parameters.Add(Result);

                    cmd.Parameters.AddWithValue("@IdIngreso", l.IdIngreso);
                    cmd.Parameters.AddWithValue("@NumeroIngreso", l.NumeroIngreso);
                    cmd.Parameters.AddWithValue("@FechaReal", l.FechaReal);
                    cmd.Parameters.AddWithValue("@FechaIngreso", l.FechaIngreso);
                    cmd.Parameters.AddWithValue("@ComprobantePago", l.ComprobantePago);
                    cmd.Parameters.AddWithValue("@NumeroFactura", l.NumeroFactura);
                    cmd.Parameters.AddWithValue("@NumeroPreventivo", l.NumeroPreventivo);
                    cmd.Parameters.AddWithValue("@Observacion", l.Observacion);
                    cmd.Parameters.AddWithValue("@SubTotal", l.SubTotal);
                    cmd.Parameters.AddWithValue("@Total", l.Total);
                    cmd.Parameters.AddWithValue("@Descuento", l.Descuento);
                    cmd.Parameters.AddWithValue("@IdGrupoArticulo", l.IdGrupoArticulo);
                    cmd.Parameters.AddWithValue("@IdProveedor", l.IdProveedor);
                    cmd.Parameters.AddWithValue("@IdGestion", l.IdGestion);
                    cmd.Parameters.AddWithValue("@IdEntidad", l.IdEntidad);
                    cmd.Parameters.AddWithValue("@IdUsuarioIngreso", l.IdUsuarioIngreso);
                    cmd.Parameters.AddWithValue("@IdAlmacen", l.IdAlmacen);
                    cmd.Parameters.AddWithValue("@IdEstadoIngreso", l.IdEstadoIngreso);
                    cmd.Parameters.AddWithValue("@FechaRegistro", l.FechaRegistro);
                    cmd.Parameters.AddWithValue("@EstadoRegistro", l.EstadoRegistro);
                    cmd.Parameters.AddWithValue("@IdTipoDocumentoEntrega", l.IdTipoDocumentoEntrega);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();

                    if (t == "c")
                        l.IdIngreso = int.Parse(Result.Value.ToString());
                }
            }
            return l;
        }

        public async Task Eliminar(int idIngreso)
        {
            using (SqlConnection con = new SqlConnection(conect))
            {
                string cadena = "DELETE FROM trnIngreso WHERE IdIngreso = @IdIngreso";

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);

                    await con.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<trnIngreso> Buscar(int idIngreso)
        {
            trnIngreso l = null;

            using (SqlConnection con = new SqlConnection(conect))
            {
                string cadena = "SELECT * FROM trnIngreso WHERE IdIngreso = @IdIngreso";

                using (SqlCommand cmd = new SqlCommand(cadena, con))
                {
                    cmd.Parameters.AddWithValue("@IdIngreso", idIngreso);

                    await con.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            l = new trnIngreso();
                            l.IdIngreso = Convert.ToInt32(reader["IdIngreso"]);
                            l.NumeroIngreso = Convert.ToString(reader["NumeroIngreso"]);
                            l.FechaReal = Convert.ToDateTime(reader["FechaReal"]);
                            l.FechaIngreso = Convert.ToDateTime(reader["FechaIngreso"]);
                            l.ComprobantePago = Convert.ToString(reader["ComprobantePago"]);
                            l.NumeroFactura = Convert.ToString(reader["NumeroFactura"]);
                            l.NumeroPreventivo = Convert.ToString(reader["NumeroPreventivo"]);
                            l.Observacion = Convert.ToString(reader["Observacion"]);
                            l.SubTotal = Convert.ToDecimal(reader["SubTotal"]);
                            l.Total = Convert.ToDecimal(reader["Total"]);
                            l.Descuento = Convert.ToDecimal(reader["Descuento"]);
                            l.IdGrupoArticulo = Convert.ToInt32(reader["IdGrupoArticulo"]);
                            l.IdProveedor = Convert.ToInt32(reader["IdProveedor"]);
                            l.IdGestion = Convert.ToInt32(reader["IdGestion"]);
                            l.IdEntidad = Convert.ToInt32(reader["IdEntidad"]);
                            l.IdUsuarioIngreso = Convert.ToInt32(reader["IdUsuarioIngreso"]);
                            l.IdAlmacen = Convert.ToInt32(reader["IdAlmacen"]);
                            l.IdEstadoIngreso = Convert.ToInt32(reader["IdEstadoIngreso"]);
                            l.FechaRegistro = Convert.ToDateTime(reader["FechaRegistro"]);
                            l.EstadoRegistro = Convert.ToString(reader["EstadoRegistro"]);
                            l.IdTipoDocumentoEntrega = Convert.ToInt32(reader["IdTipoDocumentoEntrega"]);
                        }
                    }
                }
            }
            return l;
        }

    }
}
