namespace Ametrano.Persistencia
{
    class ConsultasSQL
    {
        public string agregarDocente() {
            string query = "INSERT INTO docente VALUES(@cedula,@nombre1,@nombre2,@apellido1,@apellido2,@direccion,@telefono,@email)";
            return query;
        }





    }
}
