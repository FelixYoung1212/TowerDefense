using GameFramework.DataTable;

namespace cfg
{
    public sealed partial class Item : IDataRow
    {
        int IDataRow.Id => Id;
    }

    public sealed partial class Item1 : IDataRow
    {
        int IDataRow.Id => Id;
    }

    public sealed partial class Item2 : IDataRow
    {
        int IDataRow.Id => Id;
    }
}
