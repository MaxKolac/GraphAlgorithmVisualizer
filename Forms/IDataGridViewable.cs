using GraphAlgorithmVisualizer.MathObjects;

namespace GraphAlgorithmVisualizer.Forms
{
    /// <summary>
    /// Interface implemented by Algorithms which can return their various output Dictionairies&lt;Vertex, value&gt; and can be viewed in MainForm's Algorithm output DataGridView.
    /// <para>As of right now, implementing classes can only show results for 2 of their Dictionairies.</para>
    /// </summary>
    internal interface IDataGridViewable<A, B>
    {
        /// <returns>The label for the first data column.</returns>
        string GetFirstColumnLabel();
        /// <returns>The label for the second data column.</returns>
        string GetSecondColumnLabel();
        /// <returns>The value of KeyValuePair for the given Vertex key, to show in the first column.</returns>
        A GetFirstColumnDataForVertex(Vertex v);
        /// <returns>The value of KeyValuePair for the given Vertex key, to show in the second column.</returns>
        B GetSecondColumnDataForVertex(Vertex v);
        /// <returns>The label which shows the sum of all performed operations.</returns>
        string GetOperationsPerformed();
    }
}
