﻿using System;

using LinqToDB;

using NTSG = NetTopologySuite.Geometries.Geometry;

namespace LinqToDBPostGisNetTopologySuite
{
    /// <summary>
    /// Geometry Editors.
    /// </summary>
    /// <remarks>
    /// 5.5. Geometry Editors
    /// https://postgis.net/docs/reference.html#Geometry_Editors
    /// </remarks>
    public static class GeometryEditors
    {
        /// <summary>
        /// Append a point to a LineString
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AddPoint.html
        /// </remarks>
        /// <param name="lineString">LineString</param>
        /// <param name="point">Point</param>
        /// <returns>LineString with point appended</returns>
        [Sql.Function("ST_AddPoint", ServerSideOnly = true)]
        public static NTSG STAddPoint(this NTSG lineString, NTSG point)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Insert a point to a LineString at given position(zero based)
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_AddPoint.html
        /// </remarks>
        /// <param name="lineString">Linestring</param>
        /// <param name="point">Point</param>
        /// <param name="position">Insert position(zero based)</param>
        /// <returns>LineString with point inserted</returns>
        [Sql.Function("ST_AddPoint", ServerSideOnly = true)]
        public static NTSG STAddPoint(this NTSG lineString, NTSG point, int position)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Given a (multi)geometry, returns a (multi)geometry consisting only of elements of the specified type. If there are no sub-geometries of the right type, an EMPTY geometry will be returned
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CollectionExtract.html
        /// </remarks>
        /// <param name="collection">Geometry</param>
        /// <param name="type">Type(1 == POINT, 2 == LINESTRING, 3 == POLYGON)</param>
        /// <returns>Geometry consisting only of elements of the specified type</returns>
        [Sql.Function("ST_CollectionExtract", ServerSideOnly = true)]
        public static NTSG STCollectionExtract(this NTSG collection, int type)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Given a geometry collection, returns the "simplest" representation of the contents
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_CollectionHomogenize.html
        /// </remarks>
        /// <param name="collection">Geometry collection</param>
        /// <returns>Simplest" representation of the geometry collection</returns>
        [Sql.Function("ST_CollectionHomogenize", ServerSideOnly = true)]
        public static NTSG STCollectionHomogenize(this NTSG collection)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into a "2-dimensional mode" so that all output representations will only have the X and Y coordinates
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force2D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XY mode</returns>
        [Sql.Function("ST_Force2D", ServerSideOnly = true)]
        public static NTSG STForce2D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYZ mode. This is an alias for ST_Force_3DZ. If a geometry has no Z component, then a 0 Z coordinate is tacked on
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYZ mode</returns>
        [Sql.Function("ST_Force3D", ServerSideOnly = true)]
        public static NTSG STForce3D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYZ mode. This is a synonym for ST_Force3DZ. If a geometry has no Z component, then a 0 Z coordinate is tacked on
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3DZ.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYZ mode</returns>
        [Sql.Function("ST_Force3DZ", ServerSideOnly = true)]
        public static NTSG STForce3DZ(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYM mode. If a geometry has no M component, then a 0 M coordinate is tacked on. If it has a Z component, then Z is removed
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_3DM.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYM mode</returns>
        [Sql.Function("ST_Force3DM", ServerSideOnly = true)]
        public static NTSG STForce3DM(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the geometries into XYZM mode. 0 is tacked on for missing Z and M dimensions.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_4D.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry in XYZM mode</returns>
        [Sql.Function("ST_Force4D", ServerSideOnly = true)]
        public static NTSG STForce4D(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces (Multi)Polygons to use a counter-clockwise orientation for their exterior ring, and a clockwise orientation for their interior rings.Non-polygonal geometries are returned unchanged
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForcePolygonCCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry with counter-clockwise/clockwise exterior/interior orientaion ring</returns>
        [Sql.Function("ST_ForcePolygonCCW ", ServerSideOnly = true)]
        public static NTSG STForcePolygonCCW(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Converts the geometry into a GEOMETRYCOLLECTION
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Force_Collection.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry Collection</returns>
        [Sql.Function("ST_ForceCollection ", ServerSideOnly = true)]
        public static NTSG STForceCollection(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces (Multi)Polygons to use a clockwise orientation for their exterior ring, and a counter-clockwise orientation for their interior rings. Non-polygonal geometries are returned unchanged
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForcePolygonCW.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry with counter-clockwise/clockwise interior/exterior orientaion ring</returns>
        [Sql.Function("ST_ForcePolygonCW", ServerSideOnly = true)]
        public static NTSG STForcePolygonCW(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the input <paramref name="geometry"/> to use SFS 1.1 geometry types only.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceSFS.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ForceSFS", ServerSideOnly = true)]
        public static NTSG STForceSFS(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        // TODO: geometry ST_ForceSFS(geometry geomA, text version);

        /// <summary>
        /// Forces the input <paramref name="geometry"/> in text representation to use SFS 1.1 geometry types only.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceSFS.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_ForceSFS", ServerSideOnly = true)]
        public static NTSG STForceSFS(string geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Forces the orientation of the vertices in a polygon to follow a Right-Hand-Rule, in which the area that is bounded by the polygon is to the right of the boundary. In particular, the exterior ring is orientated in a clockwise direction and the interior rings in a counter-clockwise direction
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceRHR.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry with vertices following a Right-Hand-Rule</returns>
        [Sql.Function("ST_ForceRHR", ServerSideOnly = true)]
        public static NTSG STForceRHR(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Turns a geometry into its curved representation. Lines become compoundcurves, multilines become multicurves, polygons become curvepolygons, multipolygons become multisurfaces. A curved geometry returns back same as input
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_ForceCurve.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry with curved representation</returns>
        [Sql.Function("ST_ForceCurve", ServerSideOnly = true)]
        public static NTSG STForceCurve(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a (set of) LineString(s) formed by sewing together the constituent line work of a MULTILINESTRING(Only use with MULTILINESTRING/LINESTRINGs. If you feed a polygon or geometry collection into this function, it will return an empty GEOMETRYCOLLECTION)
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_LineMerge.html
        /// </remarks>
        /// <param name="geometry">Input geometry(MULTILINESTRING/LINESTRINGs only,polygon/geometry collection will return empty geomtry collection)</param>
        /// <returns>A (set of) LineString(s) formed by sewing together the constituent line work of a MULTILINESTRING</returns>
        [Sql.Function("ST_LineMerge", ServerSideOnly = true)]
        public static NTSG STLineMerge(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns the geometry as a MULTI* geometry. If the geometry is already a MULTI*, it is returned unchanged
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Multi.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>A MULTI* geometry</returns>
        [Sql.Function("ST_Multi", ServerSideOnly = true)]
        public static NTSG STMulti(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry in its normalized/canonical form.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Normalize.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Normalized geometry</returns>
        [Sql.Function("ST_Normalize", ServerSideOnly = true)]
        public static NTSG STNormalize(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns input <paramref name="geometry"/> with its coordinates quantized.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_QuantizeCoordinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="precisionX">Precision for X coordinate.</param>
        /// <param name="precisionY">Precision for Y coordinate.</param>
        /// <param name="precisionZ">Precision for Z coordinate.</param>
        /// <param name="precisionM">Precision for M coordinate.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_QuantizeCoordinates", ServerSideOnly = true)]
        public static NTSG STQuantizeCoordinates(this NTSG geometry, int precisionX, int precisionY, int precisionZ, int precisionM)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns input <paramref name="geometry"/> with its coordinates quantized.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_QuantizeCoordinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="precision">Precision for X, Y, Z, M coordinates.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_QuantizeCoordinates", ServerSideOnly = true)]
        public static NTSG STQuantizeCoordinates(this NTSG geometry, int precision)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Removes point from input geometry (LineString)
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_RemovePoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString)</param>
        /// <param name="index">Index of point to remove (zero-based)</param>
        /// <returns>Geometry with point removed</returns>
        [Sql.Function("ST_RemovePoint", ServerSideOnly = true)]
        public static NTSG STRemovePoint(this NTSG geometry, int index) // TODO: test
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns geometry with reversed order of the vertexes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Reverse.html
        /// </remarks>
        /// <param name="geometry">Input geometry</param>
        /// <returns>Geometry with reversed order of the vertexes</returns>
        [Sql.Function("ST_Reverse", ServerSideOnly = true)]
        public static NTSG STReverse(this NTSG geometry)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a modified input <paramref name="geometry"/> having no segment longer than the given <paramref name="maxSegmentLength"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Segmentize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxSegmentLength">Max segment length.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Segmentize", ServerSideOnly = true)]
        public static NTSG STSegmentize(this NTSG geometry, double maxSegmentLength)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a modified input <paramref name="geometry"/> in text represenation having no segment longer than the given <paramref name="maxSegmentLength"/>.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Segmentize.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="maxSegmentLength">Max segment length.</param>
        /// <returns>Geometry.</returns>
        [Sql.Function("ST_Segmentize", ServerSideOnly = true)]
        public static NTSG STSegmentize(string geometry, double maxSegmentLength)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Replace point of input geometry with given point.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SetPoint.html
        /// </remarks>
        /// <param name="geometry">Input geometry (LineString)</param>
        /// <param name="index">Index of point to remove (zero-based)</param>
        /// <param name="point">New point</param>
        /// <returns>Geometry with point replaced</returns>
        [Sql.Function("ST_SetPoint", ServerSideOnly = true)]
        public static NTSG STSetPoint(this NTSG geometry, int index, NTSG point)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its origin and cell size.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="originX">X coordinate of grid origin.</param>
        /// <param name="originY">Y coordinate of grid origin.</param>
        /// <param name="sizeX">Grid cell size by X axis.</param>
        /// <param name="sizeY">Grid cell size by Y axis.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, double originX, double originY, double sizeX, double sizeY)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its cell size.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="sizeX">Grid cell size by X axis.</param>
        /// <param name="sizeY">Grid cell size by Y axis.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, double sizeX, double sizeY)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its cell size.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="size">Grid cell size.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, double size)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Snaps all points of input <paramref name="geometry"/> to the grid defined by its origin point and cell sizes.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SnapToGrid.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="origin">Grid origin (Point).</param>
        /// <param name="sizeX">Grid cell size by X axis.</param>
        /// <param name="sizeY">Grid cell size by Y axis.</param>
        /// <param name="sizeZ">Grid cell size by Z axis.</param>
        /// <param name="sizeM">Grid cell size by M axis.</param>
        /// <returns>Geometry with all points snapped to grid.</returns>
        [Sql.Function("ST_SnapToGrid", ServerSideOnly = true)]
        public static NTSG STSnapToGrid(this NTSG geometry, NTSG origin, double sizeX, double sizeY, double sizeZ, double sizeM)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Snaps the vertices and segments of input <paramref name="geometry"/> to <paramref name="reference"/> geometry vertices.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_Snap.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="reference">Reference geometry.</param>
        /// <param name="tolerance">Snap distance tolerance.</param>
        /// <returns>Geometry with the vertices snapped.</returns>
        [Sql.Function("ST_Snap", ServerSideOnly = true)]
        public static NTSG STSnap(this NTSG geometry, NTSG reference, double tolerance)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a version of input <paramref name="geometry"/> with given ordinates swapped.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SwapOrdinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="ordinates">Two-characters string naming the ordinates to swap. Valid names are: x,y,z and m.</param>
        /// <returns>Geometry with given ordinates swapped.</returns>
        [Sql.Function("ST_SwapOrdinates", ServerSideOnly = true)]
        public static NTSG STSwapOrdinates(this NTSG geometry, string ordinates)
        {
            throw new InvalidOperationException();
        }

        /// <summary>
        /// Returns a version of input <paramref name="geometry"/> in text representation with given ordinates swapped.
        /// </summary>
        /// <remarks>
        /// See https://postgis.net/docs/ST_SwapOrdinates.html
        /// </remarks>
        /// <param name="geometry">Input geometry.</param>
        /// <param name="ordinates">Two-characters string naming the ordinates to swap. Valid names are: x,y,z and m.</param>
        /// <returns>Geometry with given ordinates swapped.</returns>
        [Sql.Function("ST_SwapOrdinates", ServerSideOnly = true)]
        public static NTSG STSwapOrdinates(string geometry, string ordinates)
        {
            throw new InvalidOperationException();
        }
    }
}
