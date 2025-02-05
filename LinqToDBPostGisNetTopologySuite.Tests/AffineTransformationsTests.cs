using System;
using System.Linq;

using LinqToDB;
using NUnit.Framework;

using NTSGS = NetTopologySuite.Geometries;

namespace LinqToDBPostGisNetTopologySuite.Tests
{
    [TestFixture]
    class AffineTransformationsTests : TestsBase
    {
        [SetUp]
        public void Setup()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                db.TestGeometries.Truncate();
                db.TestGeographies.Truncate();
            }
        }

        [Test]
        public void TestSTAffine3D()
        {
            var expected = new double[][]
                {
                    new[]{ -1.0, -2.0, 3.0 },
                    new[]{ -1.0, -4.0, 3.0 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 4 3)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAffine(
                            Math.Cos(Math.PI), -1 * Math.Sin(Math.PI), 0,
                            Math.Sin(Math.PI), Math.Cos(Math.PI), 0,
                            0, 0, 1,
                            0, 0, 0))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                .Select(() => AffineTransformations.STAffine(
                        Wkt,
                        Math.Cos(Math.PI), -1 * Math.Sin(Math.PI), 0,
                        Math.Sin(Math.PI), Math.Cos(Math.PI), 0,
                        0, 0, 1,
                        0, 0, 0)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTAffine2D()
        {
            var expected = new double[][]
                {
                    new[]{ 0.0, 0.0, 3.0 },
                    new[]{ 0.0, 0.0, 3.0 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 4 3)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STAffine(0, 0, 0, 0, 0, 0))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STAffine(Wkt, 0, 0, 0, 0, 0, 0)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTRotate()
        {
            var expected = new double[][]
                {
                    new[]{-50.0, -160.0},
                    new[]{-50.0, -50.0},
                    new[]{-100.0, -50.0}
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING (50 160, 50 50, 100 50)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotate(Math.PI))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STRotate(Wkt, Math.PI)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTRotateOrigin()
        {
            var expected = new double[][]
                {
                    new[]{ 50.00, 160.0 },
                    new[]{ 105.0, 64.73720558371174 },
                    new[]{ 148.30127018922192, 89.73720558371173 }
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING (50 160, 50 50, 100 50)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotate(Math.PI / 6.0, 50, 160))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STRotate(Wkt, Math.PI / 6.0, 50, 160)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTRotateOriginGeom()
        {
            var expected = new double[][]
                {
                    new[]{ 116.42245883568916, 130.67207346706593 },
                    new[]{ 21.15966441940092, 75.67207346706593 },
                    new[]{ 46.15966441940093, 32.370803277844 }
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING (50 160, 50 50, 100 50)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotate(-1.0 * Math.PI / 3.0, g.Geometry.STCentroid()))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var origin = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STCentroid())
                    .Single() as NTSGS.Point;

                var result2 = db
                    .Select(() => AffineTransformations.STRotate(Wkt, -1.0 * Math.PI / 3.0, origin)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTRotateX()
        {
            var expected = new double[][]
                {
                    new[]{ 1.0, -3.0, 2.0 },
                    new[]{ 1.0, -1.0, 1.0 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotateX(Math.PI / 2.0))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result1, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STRotateX(Wkt, Math.PI / 2.0)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTRotateY()
        {
            var expected = new double[][]
                {
                    new[]{ 3.0, 2.0, -1.0 },
                    new[]{ 1.0, 1.0, -1.0 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result1 = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotateY(Math.PI / 2.0))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result1, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STRotateY(Wkt, Math.PI / 2.0)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTRotateZ()
        {
            var expected = new double[][]
                {
                    new[]{ -2.0, 1.0, 3.0 },
                    new[]{ -1.0, 1.0, 1.0 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STRotateZ(Math.PI / 2.0))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STRotateZ(Wkt, Math.PI / 2.0)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTScaleXYZ()
        {
            var expected = new double[][]
                {
                    new[]{ 0.5, 1.5, 2.4 },
                    new[]{ 0.5, 0.75, 0.8 }
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(0.5, 0.75, 0.8))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STScale(Wkt, 0.5, 0.75, 0.8)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTScaleXY()
        {
            var expected = new double[][]
                {
                    new[]{ 0.5, 1.5, 3 },
                    new[]{ 0.5, 0.75, 1 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(0.5, 0.75))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STScale(Wkt, 0.5, 0.75)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTScaleXYZM()
        {
            var expected = new double[][]
                {
                    new[]{ 0.5, 1.5, 6.0, -4.0 },
                    new[]{ 0.5, 0.75, 2.0, -1.0 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3 4, 1 1 1 1)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(GeometryConstructors.STMakePoint(0.5, 0.75, 2, -1)))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STScale(Wkt, GeometryConstructors.STMakePoint(0.5, 0.75, 2, -1)))as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTScaleFalseOrigin()
        {
            var expected = new double[][]
                {
                    new[]{ 1.00, 1.00 },
                    new[]{ 3.00, 3.00 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 1, 2 2)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromEWKT(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STScale(GeometryInput.STGeomFromEWKT("POINT(2 2)"), GeometryInput.STGeomFromEWKT("POINT(1 1)")))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STScale(
                        Wkt,
                        GeometryInput.STGeomFromEWKT("POINT(2 2)"),
                        GeometryInput.STGeomFromEWKT("POINT(1 1)"))) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        [Test]
        public void TestSTTranslatedXY()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POINT(-71.01 42.37)";
                db.TestGeometries
                    .Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt, 4326))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STTranslate(1, 0).STAsText())
                    .Single();

                Assert.AreEqual("POINT(-70.01 42.37)", result);

                var result2 = db
                    .Select(() => AffineTransformations.STTranslate(Wkt, 1, 0).STAsText());

                Assert.AreEqual("POINT(-70.01 42.37)", result2);
            }
        }

        [Test]
        public void TestSTTranslatedXYZ()
        {
            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "POINT(0 0 0)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STTranslate(5, 12, 3))
                    .Select(g => GeometryOutput.STAsEWKT(g))
                    .Single();

                Assert.AreEqual("POINT(5 12 3)", result);

                var result2 = db
                    .Select(() => AffineTransformations.STTranslate(Wkt, 5, 12, 3).STAsEWKT());

                Assert.AreEqual("POINT(5 12 3)", result2);
            }
        }

        [Test]
        public void TestSTTransScale()
        {
            var expected = new double[][]
                {
                    new[]{ 1.5, 6, 3 },
                    new[]{ 1.5, 4, 1 },
                };

            using (var db = new PostGisTestDataConnection(TestDatabaseConnectionString))
            {
                const string Wkt = "LINESTRING(1 2 3, 1 1 1)";
                db.TestGeometries.Value(g => g.Id, 1)
                    .Value(g => g.Geometry, () => GeometryInput.STGeomFromText(Wkt))
                    .Insert();

                var result = db.TestGeometries
                    .Where(g => g.Id == 1)
                    .Select(g => g.Geometry.STTransScale(0.5, 1, 1, 2))
                    .Single() as NTSGS.LineString;

                CheckLineEquals(expected, result, 1.0E-8);

                var result2 = db
                    .Select(() => AffineTransformations.STTransScale(Wkt, 0.5, 1, 1, 2)) as NTSGS.LineString;

                CheckLineEquals(expected, result2, 1.0E-8);
            }
        }

        private static void CheckLineEquals(double[][] expected, NTSGS.LineString actual, double tolerance)
        {
            var pointsCount = expected.Length;
            var dimensionCount = expected[0].Length; // Depends on 2D / 3D geometry dimensions

            for (var i = 0; i < pointsCount; i++)
            {
                for (var j = 0; j < dimensionCount; j++)
                {
                    var exp = expected[i][j];
                    var res = actual.GetCoordinateN(i).CoordinateValue[j];

                    Assert.AreEqual(exp, res, tolerance);
                }
            }
        }
    }
}
