namespace Stos
{
    /// <summary>
    /// Interfejs stosu (generyczny)
    /// </summary>
    /// <remarks>
    /// Za�o�enia:
    /// 1. Po utworzeniu stos jest pusty
    /// 2. Stos jest pojemnikiem o nieograniczonej pojemno�ci
    /// 3. Pr�ba zdj�cia lub odczytania szczytowego elementu ze stosu pustego zg�asza wyj�tek
    /// 4. Push oraz Pop s� czynno�ciami wzajemnie odwrotnymi
    /// Dodatkowe:
    /// Stos mo�na przegl�da� bez mo�liwo�ci zmiany element�w (read-only)
    /// </remarks>
    /// <typeparam name="T">dowolny typ warto�ciowy lub referencyjny</typeparam>
    /// 
    public interface IStos<T>
    {
        //w interfejsie nie deklaruje si� konstruktora

        //wstawia element typu T na stos
        void Push(T value);

        //zwraca szczytowy element stosu
        T Peek { get; }

        //zdejmuje szczytowy element ze stosu
        T Pop();

        //zwraca liczb� element�w na stosie
        int Count { get; }

        //zwraca true, je�li stos jest pusty, a false w przeciwnym przypadku
        bool IsEmpty { get; }

        //opr�nia stos
        void Clear();

        //kopiuje i eksportuje stos do tablicy
        T[] ToArray();
        T this[int index] { get; }
    }
}