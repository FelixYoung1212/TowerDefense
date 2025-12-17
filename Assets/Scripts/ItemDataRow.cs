using UnityGameFramework.Runtime;

namespace DefaultNamespace
{
    public class ItemDataRow : DataRowBase
    {
        public override int Id { get; }

        public override bool ParseDataRow(string dataRowString, object userData)
        {
            return false;
        }

        public override bool ParseDataRow(byte[] dataRowBytes, int startIndex, int length, object userData)
        {
            return false;
        }
    }
}