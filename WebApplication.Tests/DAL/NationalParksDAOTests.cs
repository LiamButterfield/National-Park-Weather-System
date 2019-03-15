using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Transactions;
using System.Data.SqlClient;
using WebApplication.Web.Models;

namespace WebApplication.Tests.DAL
{
    [TestClass]
    public class NationalParksDAOTests
    {
        protected string ConnectionString { get; } = "Server=.\\SQLEXPRESS;Database=NPGeek;Trusted_Connection=True;";
        
        /// <summary>
        /// Holds the newly generated survey id
        /// </summary>
        protected int NewSurveyId { get; private set; }

        /// <summary>
        /// The transaction for each test.
        /// </summary>
        private TransactionScope transaction;
        
        [TestInitialize]
        public void Setup()
            {
                // Begin the transaction
                transaction = new TransactionScope();

                // Get the SQL Script to run
                string sql = File.ReadAllText("test-script.sql");

                // Execute the script
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                }

            }
        
        [TestCleanup]
        public void Cleanup()
            {
                // Roll back the transaction
                transaction.Dispose();
            }
        
        /// <summary>
        /// Gets the row count for a table.
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        protected int GetRowCount(string table)
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());
                    return count;
                }
            }
        
    }
}
