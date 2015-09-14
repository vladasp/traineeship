using System;
namespace Chapter_3
{
    class Exercise1
    {
        public void Show()
        {
            Console.WriteLine(@"
            namespace fabulous
                {
                    /// <summary> reference to name 'great'
                    ///     super.smashing.great
                    /// </summary>
                }

            namespace super
            {
                namespace smashing
                {
                    // definition of name 'great' 
                }
            }
                            ");
        }
    }
}

