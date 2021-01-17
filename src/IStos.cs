namespace Stos
{
    /// <summary>
    /// Interfejs stosu (generyczny)
    /// </summary>
    /// <remarks>
    /// Za³o¿enia:
    /// 1. Po utworzeniu stos jest pusty
    /// 2. Stos jest pojemnikiem o nieograniczonej pojemnoœci
    /// 3. Próba zdjêcia lub odczytania szczytowego elementu ze stosu pustego zg³asza wyj¹tek
    /// 4. Push oraz Pop s¹ czynnoœciami wzajemnie odwrotnymi
    /// Dodatkowe:
    /// Stos mo¿na przegl¹daæ bez mo¿liwoœci zmiany elementów (read-only)
    /// </remarks>
    /// <typeparam name="T">dowolny typ wartoœciowy lub referencyjny</typeparam>
    /// 
    public interface IStos<T>
    {
        //w interfejsie nie deklaruje siê konstruktora

        //wstawia element typu T na stos
        void Push(T value);

        //zwraca szczytowy element stosu
        T Peek { get; }

        //zdejmuje szczytowy element ze stosu
        T Pop();

        //zwraca liczbê elementów na stosie
        int Count { get; }

        //zwraca true, jeœli stos jest pusty, a false w przeciwnym przypadku
        bool IsEmpty { get; }

        //opró¿nia stos
        void Clear();

        //kopiuje i eksportuje stos do tablicy
        T[] ToArray();
        T this[int index] { get; }
    }
}