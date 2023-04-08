namespace GraphAlgorithmVisualizer.MathObjects
{
    internal class Matrix
    {
        /// <summary>
        /// The primitive matrix array with two dimensions.
        /// </summary>
        private readonly int[,] matrix;
        /// <summary>
        /// Defines what type of matrix representation is stored in this matrix.
        /// </summary>
        public readonly MatrixGraphRepresentation RepresentationType;
        /// <summary>
        /// Readonly indexer for reading <c>Matrix</c>'s values.
        /// </summary>
        /// <param name="x">The X coordinate of the value to retrieve.</param>
        /// <param name="y">The Y coordinate of the value to retrieve.</param>
        /// <returns>The <c>Matrix</c>'s value under [X,Y] coordinates.</returns>
        public int this[int x, int y] { get { return matrix[x, y]; } set { Set(x, y, value); } }

        /// <summary>
        /// Creates a new <c>Matrix</c>.
        /// </summary>
        /// <param name="x">The x dimension of the matrix.</param>
        /// <param name="y">The y dimension of the matrix.</param>
        /// <param name="representationType">Which matrix graph representation will this matrix visualize.</param>
        public Matrix(int x, int y, MatrixGraphRepresentation representationType)
        {
            matrix = new int[x, y];
            RepresentationType = representationType;
        }

        /// <summary>
        /// Sets a value on the <c>Matrix</c>'s specified <c>(x, y)</c> element.
        /// </summary>
        /// <param name="x">The X coordinate of the target element.</param>
        /// <param name="y">The Y coordinate of the target element.</param>
        /// <param name="value">The new value of <c>Matrix</c>'s <c>(x, y)</c> element.</param>
        public void Set(int x, int y, int value) => matrix[x, y] = value;
    }

    internal enum MatrixGraphRepresentation
    {
        /// <summary>
        /// (Macierz sąsiedztwa) - If we have <c>n</c> vertices, that is V1, V2, ..., Vn, then adjacency matrix is a table with <c>n x n</c> dimensions, where each <c>(i, j)</c> element is equal to:
        /// <list type="bullet">
        /// <item>1 - if there exists an Edge starting from Vi and ending in Vj.</item>
        /// <item>0 - If otherwise.</item>
        /// </list>
        /// </summary>
        AdjacencyRepresentation,
        /// <summary>
        /// (Macierz incydencji) - If we have <c>n</c> vertices, that is V1, V2, ..., Vn, and if all Edges of a Graph have an identifying integer assigned {1, 2, 3, ..., m}, then incident matrix is a matrix with <c>n x m</c> dimensions, where each <c>(i, j)</c> element equals:
        /// <list type="bullet">
        /// <item>1, if the <c>Vertex "i"</c> is <b>bidirectional</b> with <c>Vertex "j"</c>.</item>
        /// <item>0 - If otherwise.</item>
        /// </list>
        /// </summary>
        IncidenceRepresentation
    }
}
