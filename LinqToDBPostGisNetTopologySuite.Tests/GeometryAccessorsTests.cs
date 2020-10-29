﻿using System.Linq;

using LinqToDB;
using NUnit.Framework;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class GeometryAccessorsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Delete();
            }
        }

        [Test]
        public void TestGeometryType()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var geometryType = db.TestGeometries.Select(g => g.Geometry.GeometryType()).Single();

                Assert.AreEqual("LINESTRING", geometryType);
            }
        }

        [Test]
        public void TestSTBoundary()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(100 150,50 60, 70 80, 160 170)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POLYGON (( 10 130, 50 190, 110 190, 140 150, 150 80, 100 10, 20 40, 10 130), (70 40, 100 50, 120 80, 80 110, 50 90, 70 40))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var boundary1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STBoundary().STAsText()).Single();
                Assert.AreEqual("MULTIPOINT(100 150,160 170)", boundary1);

                var boundary2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STBoundary().STAsText()).Single();
                Assert.AreEqual("MULTILINESTRING((10 130,50 190,110 190,140 150,150 80,100 10,20 40,10 130),(70 40,100 50,120 80,80 110,50 90,70 40))", boundary2);
            }
        }

        [Test]
        public void TestSTDimension()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "GEOMETRYCOLLECTION(LINESTRING(1 1,0 0),POINT(0 0))";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var dimension = db.TestGeometries.Select(g => g.Geometry.STDimension()).Single();

                Assert.AreEqual(1, dimension);
            }
        }

        [Test]
        public void TestSTEndPoint()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(1 1, 2 2, 3 3)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var endPoint = db.TestGeometries.Select(g => g.Geometry.STEndPoint().STAsText()).Single();

                Assert.AreEqual("POINT(3 3)", endPoint);
            }
        }

        [Test]
        public void TestSTEnvelope()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(0 0, 1 3)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var envelope = db.TestGeometries.Select(g => g.Geometry.STEnvelope().STAsText()).Single();

                Assert.AreEqual("POLYGON((0 0,0 3,1 3,1 0,0 0))", envelope);
            }
        }

        [Test]
        public void TestSTIsEmpty()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "GEOMETRYCOLLECTION EMPTY";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POLYGON((1 2, 3 4, 5 6, 1 2))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();
                db.TestGeometries.Value(g => g.Id, 3).Value(p => p.Geometry, () => null).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsEmpty()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsEmpty()).Single());
                Assert.IsNull(db.TestGeometries.Where(g => g.Id == 3).Select(g => g.Geometry.STIsEmpty()).Single());
            }
        }

        [Test]
        public void TestSTIsValid()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(0 0, 1 1)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POLYGON((0 0, 1 1, 1 2, 1 1, 0 0))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                Assert.IsTrue(db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STIsValid()).Single());
                Assert.IsFalse(db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STIsValid()).Single());
            }
        }

        [Test]
        public void TestSTNumGeometries()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "GEOMETRYCOLLECTION(MULTIPOINT(-2 3 , -2 2), LINESTRING(5 5, 10 10), POLYGON((-7 4.2, -7.1 5, -7.1 4.3, -7 4.2)))";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var numGeometries1 = db.TestGeometries.Where(g => g.Id == 1).Select(g => g.Geometry.STNumGeometries()).Single();
                Assert.AreEqual(1, numGeometries1);

                var numGeometries2 = db.TestGeometries.Where(g => g.Id == 2).Select(g => g.Geometry.STNumGeometries()).Single();
                Assert.AreEqual(3, numGeometries2);
            }
        }

        [Test]
        public void TestSTNumPoints()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt = "LINESTRING(77.29 29.07,77.42 29.26,77.27 29.31,77.29 29.07)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt)).Insert();

                var numPoints = db.TestGeometries.Select(g => g.Geometry.STNumPoints()).Single();

                Assert.AreEqual(4, numPoints);
            }
        }

        [Test]
        public void TestSTXYZM()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string wkt1 = "POINT(1 2 3 4)";
                db.TestGeometries.Value(g => g.Id, 1).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt1)).Insert();
                const string wkt2 = "POINT(1 2)";
                db.TestGeometries.Value(g => g.Id, 2).Value(p => p.Geometry, () => GeometryInput.STGeomFromText(wkt2)).Insert();

                var query1 = db.TestGeometries.Where(g => g.Id == 1);
                Assert.AreEqual(1, query1.Select(g => g.Geometry.STX()).Single());
                Assert.AreEqual(2, query1.Select(g => g.Geometry.STY()).Single());
                Assert.AreEqual(3, query1.Select(g => g.Geometry.STZ()).Single());
                Assert.AreEqual(4, query1.Select(g => g.Geometry.STM()).Single());

                var query2 = db.TestGeometries.Where(g => g.Id == 2);
                Assert.AreEqual(1, query2.Select(g => g.Geometry.STX()).Single());
                Assert.AreEqual(2, query2.Select(g => g.Geometry.STY()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STZ()).Single());
                Assert.IsNull(query2.Select(g => g.Geometry.STM()).Single());
            }
        }
    }
}