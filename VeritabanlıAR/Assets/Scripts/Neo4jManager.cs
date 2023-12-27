//using Neo4j.Driver;
//using UnityEngine;
//using System;

//public class Neo4jManager : MonoBehaviour
//{
//    private IDriver _driver;

//    void Start()
//    {
//        ConnectToNeo4j();
//        FetchDataFromNeo4j();
//    }

//    void ConnectToNeo4j()
//    {
//        try
//        {
//            _driver = GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("username", "password"));
//        }
//        catch (Exception e)
//        {
//            Debug.LogError($"Failed to connect to Neo4j: {e.Message}");
//        }
//    }

//    void FetchDataFromNeo4j()
//    {
//        if (_driver == null)
//        {
//            Debug.LogError("Neo4j driver is not initialized.");
//            return;
//        }

//        using (var session = _driver.Session())

//        {
//            var result = session.Run("MATCH (n:Node) RETURN n.name AS Name");

//            foreach (var record in result)
//            {
//                var name = record["Name"].As<string>();
//                Debug.Log($"Node Name: {name}");
//                // Burada elde ettiðiniz verileri Unity içinde kullanabilirsiniz.
//            }
//        }
//    }

//    void OnDestroy()
//    {
//        _driver?.Dispose();
//    }
//}
