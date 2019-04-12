using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalStat : MonoBehaviour
{
    public enum Stat
    {
        NORMAL, SCARED, AGGRESSIVE, DEPRESSED
    }

    public enum Need
    {
        NORMAL, HUNGRY, PLAYFUL, BORED, SLEEPY, THURSTY, ILL
    }

    // 내성적, 외향적, 보호적, 공격적, 의존적, 소극적, 모험적
    public enum Personality
    {
        INGOING, OUTGOING, PROTECTIVE, AGGRESSIVE, DEPENDENT, INDEPENDENT, PASSIVE, ADVENTUROUS
    }

    public enum Species
    {
        DOG, CAT
    }

    public enum Age
    {
        BABY, YOUNG, ADULT, SENIOR
    }

    public enum Sex
    {
        MALE, FEMALE, NUTEREDMALE, SPAYEDFEMALE
    }

    public enum Size
    {
        SMALL, MEDIUM, LARGE, EXTRALARGE
    }

    public struct Training
    {
        bool sit;
        bool wait;
        bool down;
        bool crate;
        bool turn;
        bool houseBroken;
    }

    // 행복도 및 신뢰도
    float happiness;
    float trust;

    // 성격 및 상태
    Stat stat;
    Need need;
    Personality[] personalities;

    // 스텟
    string name;
    float sleep;
    float hunger;
    float thurst;
    float fun;
    float health;
    Training training;
    Species species;
    Age age;
    // 생일
    int year;
    int month;
    int day;

    // Getter and Setter
    public float Happiness { get { return happiness; } set { happiness = value; } }
    public float Trust { get { return trust; } set { trust = value; } }
    public Stat GetStat { get { return stat; } set { stat = value; } }
    public Need GetNeed { get { return need; } set { need = value; } }
    public Personality[] GetPersonalities { get { return personalities; } }
    public string Name { get { return name; } set { name = value; } }
    public float Sleep { get { return sleep; } set { sleep = value; } }
    public float Hunger { get { return hunger; } set { hunger = value; } }
    public float Thurst { get { return thurst; } set { thurst = value; } }
    public float Fun { get { return fun; } set { fun = value; } }
    public float Health { get { return health; } set { health = value; } }
    public Training GetTraining { get { return training; } }
    public Species GetSpecies { get { return species; } }
    public Age GetAge { get { return age; } }
    public int Year { get { return year; } }
    public int Month { get { return month; } }
    public int Day { get { return day; } }
}
