using System;

namespace FlashDealz
{
    class FlashDealzUtility : IFlashDealz
    {
        private Products[] products;

        public FlashDealzUtility()
        {
            products = new Products[]
            {
                new Products("Laptop", 55000),
                new Products("Mobile", 30000),
                new Products("Headphones", 2000),
                new Products("Smart Watch", 8000),
                new Products("Camera", 45000)
            };
        }

        public void ShowProducts()
        {
            Console.WriteLine("\n--- Products ---");
            for (int i = 0; i < products.Length; i++)
            {
                products[i].Display();
            }
        }

        public void SortProducts()
        {
            QuickSort(products, 0, products.Length - 1);
            ShowProducts();
        }

        // ✅ QuickSort for Products
        private void QuickSort(Products[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(arr, low, high);
                QuickSort(arr, low, pivotIndex - 1);
                QuickSort(arr, pivotIndex + 1, high);
            }
        }

        private int Partition(Products[] arr, int low, int high)
        {
            double pivot = arr[high].Price;
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j].Price < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }

            Swap(arr, i + 1, high);
            return i + 1;
        }

        private void Swap(Products[] arr, int i, int j)
        {
            Products temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
    }
}
