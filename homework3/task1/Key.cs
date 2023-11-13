public enum Octave
{
    Subcontroctave = 0,
    Controctave = 3,
    Big = 15,
    Small = 27,
    First = 39,
    Second = 51,
    Third = 63,
    Fourth = 75,
    Fifth = 87
}

public enum Note
{
    C = 0, 
    D = 2,
    E = 4,
    F = 5,
    G = 7, 
    A = 9,
    B = 11
}

public enum Alteration
{
    Flat,
    Natural,
    Sharp
}

public struct Key : IComparable<Key>
{
    public Octave OctaveValue { get; }
    public Note NoteValue { get; }
    public Alteration AlterationValue { get;}
    public int KeyNumber { get; }

    public Key(Octave octaveValue, Note noteValue, Alteration alterationValue)
    {
        //У Ми и Си нет диеса (Sharp), у Фа и До -- Бемоля (Flat)
        //Субконтроктава и пятая октава на клавишных инструментах неполные
        if ((noteValue is Note.E or Note.B && alterationValue == Alteration.Sharp) ||
            (noteValue is Note.F or Note.C && alterationValue == Alteration.Flat) ||
            (octaveValue == Octave.Subcontroctave && noteValue is not (Note.A or Note.B)) ||
            (octaveValue == Octave.Fifth && (noteValue != Note.C)))
        {
            throw new ArgumentException(message: "Wrong key arguments!");
        }
        OctaveValue = octaveValue;
        NoteValue = noteValue;
        AlterationValue = alterationValue;
        KeyNumber = (int)OctaveValue + (int)NoteValue + (int)AlterationValue;
    }

    public readonly override string ToString()
    {

        return OctaveValue.ToString();
    }

    public int CompareTo(Key otherKey)
    {
        return KeyNumber - otherKey.KeyNumber;
    }

    public override bool Equals(object? otherObj)
    {
        if (otherObj is not Key otherKey)
        {
            return false;
        }

        return KeyNumber == otherKey.KeyNumber;
    }

    public override int GetHashCode()
    {
        return NoteValue.GetHashCode() + AlterationValue.GetHashCode() + OctaveValue.GetHashCode();
    }
}

