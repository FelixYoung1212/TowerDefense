using GameFramework.DataTable;

namespace cfg
{
    public sealed partial class Item : IDataRow
    {
        int IDataRow.Id => Id;
    }
}