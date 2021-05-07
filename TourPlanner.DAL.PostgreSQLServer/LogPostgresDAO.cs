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
    class LogPostgresDAO : ILogDAO
    {
        private const string SQL_FIND_BY_ID = "SELECT * FROM public.\"Logs\" WHERE \"id\" = @id;";
        private const string SQL_FIND_BY_TOUR_ID = "SELECT * FROM public.\"Logs\" " +
            "WHERE \"tour_id\" = @tourId;";
        private const string SQL_INSERT_NEW_LOG = "INSERT INTO public.\"Logs\"(report, rating, author, trip_start, trip_end, publishing_date, tour_id)" +
            "VALUES(@report, @rating, @author, @trip_start, @trip_end, @publishing_date, @tour_id);";

        private IDatabase database;
        private DAO.ITourDAO tourDAO;
        public LogPostgresDAO()
        {
            this.database = DALFactory.GetDatabase();
            this.tourDAO = DALFactory.CreateTourDAO();
        }
        public LogPostgresDAO(IDatabase database, DAO.ITourDAO tourDAO)
        {
            this.database = database;
            this.tourDAO = tourDAO;
        }
        public TourLog AddNewItemLog(DateTime publishingDate, string author, DateTime tripStart, DateTime tripEnd, Rating rating, string report, Tour tourItem)
        {
            //(@report, @rating, @author, @id, @trip_start, @trip_end, @publishing_date, @tour_id
            DbCommand insertCommand = database.CreateCommand(SQL_INSERT_NEW_LOG);
            database.DefineParameter(insertCommand, "@report", DbType.String, report);
            database.DefineParameter(insertCommand, "@author", DbType.String, author);
            database.DefineParameter(insertCommand, "@trip_start", DbType.String, tripStart.ToString());
            database.DefineParameter(insertCommand, "@trip_end", DbType.String, tripEnd.ToString());
            database.DefineParameter(insertCommand, "@publishing_date", DbType.String, publishingDate.ToString());
            database.DefineParameter(insertCommand, "@rating", DbType.Int32, (int)rating);
            database.DefineParameter(insertCommand, "@tour_id", DbType.Int32, tourItem.Id);

            return FindById(database.ExecuteScalar(insertCommand));
        }

        public TourLog FindById(int id)
        {
            DbCommand findCommand = database.CreateCommand(SQL_FIND_BY_ID);
            database.DefineParameter(findCommand, "@id", DbType.Int32, id);

            IEnumerable<TourLog> logList = QueryLogsFromDb(findCommand);
            return logList.FirstOrDefault();
        }

        public IEnumerable<TourLog> GetLogsForTour(Tour tourItem)
        {
            DbCommand getLogsCommand = database.CreateCommand(SQL_FIND_BY_TOUR_ID);
            database.DefineParameter(getLogsCommand, "@tour_id", DbType.Int32, tourItem.Id);

            return QueryLogsFromDb(getLogsCommand);
        }

        private IEnumerable<TourLog> QueryLogsFromDb(DbCommand command)
        {
            List<TourLog> logList = new List<TourLog>();
            using (IDataReader reader = database.ExecuteReader(command))
            {
                while (reader.Read())
                {
                    //report, rating, author, \"id\", trip_start, trip_end, publishing_date, tour_id
                    logList.Add(new TourLog(
                        (int)reader["id"],
                        DateTime.Parse(reader["publishing_date"].ToString()),
                        (string)reader["author"],
                        DateTime.Parse(reader["trip_start"].ToString()),
                        DateTime.Parse(reader["trip_end"].ToString()),
                        (Rating)reader["rating"],
                        (string)reader["report"],
                        tourDAO.FindById((int)reader["tour_id"])
                        ));
                }
            }
            return logList;
        }
    }
}
