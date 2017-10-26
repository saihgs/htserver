﻿using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System;

namespace HTServer.Models
{
    public class EmpMemberDepQuery

    {
        public readonly AppDb Db;
        public EmpMemberDepQuery(AppDb db)
        {
            Db = db;
        }

        public async Task<EmpMemberDep> FindOneAsync(int id)
        {
            var cmd = Db.Connection.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM `empmemberdep` WHERE `MemberID` = @id";
            cmd.Parameters.Add(new MySqlParameter
            {
                ParameterName = "@id",
                DbType = DbType.Int32,
                Value = id,
            });
            var result = await ReadAllAsync(await cmd.ExecuteReaderAsync());
            return result.Count > 0 ? result[0] : null;
        }

        public async Task<List<EmpMemberDep>> LatestPostsAsync()
        {
            var cmd = Db.Connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM `empmemberdep` ORDER BY `MemberID` DESC LIMIT 50;";//"SELECT `Id`, `Title`, `Content` FROM `emp_employer` ORDER BY `Id` DESC LIMIT 10;";
            //cmd.CommandType = CommandType.StoredProcedure;
            return await ReadAllAsync(await cmd.ExecuteReaderAsync());
        }
 
        private async Task<List<EmpMemberDep>> ReadAllAsync(DbDataReader reader)
        {
            var posts = new List<EmpMemberDep>();
            using (reader)
            {
                while (await reader.ReadAsync())
                {
                    var post = new EmpMemberDep(Db)
                    {
                        MemberID = await reader.GetFieldValueAsync<int>(0),
                        EmpId = await reader.GetFieldValueAsync<int>(1),
                        DependentID = await reader.GetFieldValueAsync<int>(2),
                        DependentType = await reader.GetFieldValueAsync<string>(3),
                        DOB = await reader.GetFieldValueAsync<DateTime>(4),
                        Sex = await reader.GetFieldValueAsync<string>(5),
                        GovtID = await reader.GetFieldValueAsync<string>(6),
                        DateAssumed = await reader.GetFieldValueAsync<DateTime>(7), 
                        LastName = await reader.GetFieldValueAsync<string>(8),
                        FirstName = await reader.GetFieldValueAsync<string>(9),
                        MiddleName = await reader.GetFieldValueAsync<string>(10),
                        NameSuffix = await reader.GetFieldValueAsync<string>(11),
                        EmailAddress = await reader.GetFieldValueAsync<string>(12),
                        PostalCode = await reader.GetFieldValueAsync<string>(13),
                        StateProvince = await reader.GetFieldValueAsync<string>(14),
                        City = await reader.GetFieldValueAsync<string>(15),
                        Street1 = await reader.GetFieldValueAsync<string>(16),
                        Street2 = await reader.GetFieldValueAsync<string>(17), 
                        AccountId = await reader.GetFieldValueAsync<string>(18),
                        IsActive = await reader.GetFieldValueAsync<int>(19),
                        CreatedAt = await reader.GetFieldValueAsync<DateTime>(20),
                        //UpdatedAt = await reader.GetFieldValueAsync<DateTime>(21)
                         UpdatedAt = await reader.IsDBNullAsync(21) ? DateTime.Now.Date : await reader.GetFieldValueAsync<DateTime>(21)
                    };
                    posts.Add(post);
                }
            }
            return posts;
        }
    }
}