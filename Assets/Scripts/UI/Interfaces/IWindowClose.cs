/*
 * author : Kirakosyan Nikita
 * e-mail : nikita.kirakosyan.work@gmail.com
 */

using Cysharp.Threading.Tasks;

namespace NikitaKirakosyan.UI
{
    public interface IWindowClose
    {
        public UniTask<bool> Close();
    }
}