using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using TourPlanner.DAL.Common;
using TourPlanner.DAL.DAO;
using TourPlanner.Models;

namespace TourPlanner.DAL.PostgreSQLServer
{
    public class TourPostgresDAO : ITourDAO
    {
        private const string SQL_FIND_BY_ID = "SELECT * FROM public.\"Tour\" WHERE \"id\" = @id;";
        private const string SQL_GET_ALL_ITEMS = "SELECT * FROM public.\"Tour\"";
        private const string SQL_INSERT_NEW_ITEM = "INSERT INTO public.\"Tour\"(name, tour_description, route_information, tour_distance, \"from\", \"to\") " +
            "VALUES(@name, @tour_description, @route_information, @tour_distance, @from, @to) " +
            "RETURNING \"id\";";


        private IDatabase database;

        public TourPostgresDAO()
        {
            this.database = DALFactory.GetDatabase();
        }
        public TourPostgresDAO(IDatabase database)
        {
            this.database = database;
        }
        public Tour AddNewItem(string name, string tourDescription, string tourDistance, string from, string to, string routeInformation)
        {
            DbCommand insertCommand = database.CreateCommand(SQL_INSERT_NEW_ITEM);
            database.DefineParameter(insertCommand, "@name", DbType.String, name);
            database.DefineParameter(insertCommand, "@tour_description", DbType.String, tourDescription);
            database.DefineParameter(insertCommand, "@route_information", DbType.String, routeInformation);
            database.DefineParameter(insertCommand, "@tour_distance", DbType.String, tourDistance.ToString());
            database.DefineParameter(insertCommand, "@from", DbType.String, from);
            database.DefineParameter(insertCommand, "@to", DbType.String, to);

            return FindById(database.ExecuteScalar(insertCommand));
        }

        public Tour CopyItem(Tour tourReference)
        {
            DbCommand insertCommand = database.CreateCommand(SQL_INSERT_NEW_ITEM);
            database.DefineParameter(insertCommand, "@name", DbType.String, tourReference.Name);
            database.DefineParameter(insertCommand, "@tour_description", DbType.String, tourReference.TourDescription);
            database.DefineParameter(insertCommand, "@route_information", DbType.String, tourReference.RouteInformation);
            database.DefineParameter(insertCommand, "@tour_distance", DbType.String, tourReference.TourDistance);
            database.DefineParameter(insertCommand, "@from", DbType.String, tourReference.From);
            database.DefineParameter(insertCommand, "@to", DbType.String, tourReference.To);

            return FindById(database.ExecuteScalar(insertCommand));
        }

        public Tour FindById(int id)
        {
            DbCommand findCommand = database.CreateCommand(SQL_FIND_BY_ID);
            database.DefineParameter(findCommand, "@id", DbType.Int32, id);
            IEnumerable<Tour> tourList = QueryToursFromDatabase(findCommand);
            return tourList.FirstOrDefault();
        }

        public IEnumerable<Tour> GetTours()
        {
            DbCommand toursCommand = database.CreateCommand(SQL_GET_ALL_ITEMS);
            //query tours from database
            return QueryToursFromDatabase(toursCommand);
        }
        //name, tour_description, route_information, tour_distance, \"from\", \"to\"
        private IEnumerable<Tour> QueryToursFromDatabase(DbCommand command)
        {
            List<Tour> tourList = new List<Tour>();
            using (IDataReader reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    tourList.Add(new Tour(
                        (int)reader["id"],
                        (string)reader["name"],
                        (string)reader["tour_description"],
                        (string)reader["tour_distance"],
                        (string)reader["from"],
                        (string)reader["to"],
                        (string)reader["route_information"]
                        ));
                }
            }
            return tourList;
        }
    }
}
