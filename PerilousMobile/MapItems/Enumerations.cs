using System;
namespace PerilousMobile
{
    public enum MapContent
    {
        ClearSpace,
        InvalidSpace,
        PrincessSpace,
        ExitSpace,
        PuzzleSpace,
        LootSpace,
        FoodSpace,
        WeaponSpace,
        MonsterSpace
    }

    public enum PuzzleKinds
    {
        maze,
        reflex,
        riddle,
        sum
    }

    public enum PuzzleDescriptions
    {
        nasty
    }


    public enum WeaponKinds
    {
        sword,
        dagger,
        axe,
        knife,
        broadsword,
        hammer
    }

    public enum WeaponDescriptions
    {
        blunt,
        sharp,
        bloodied,
        rusty,
        grimy,
        gold,
        silver,
        battered,
        twisted,
        broken
    }

    public enum LootKinds
    {
        ring,
        bottle,
        pendant,
        chain,
        locket,
        crown
    }

    public enum LootDescriptions
    {
        shiny,
        tiny,
        gold,
        silver,
        jewelled,
        painted,
        diamond,
        ruby,
        emerald,
        sapphire
    }

    public enum FoodKinds
    {
        apple,
        pie,
        stew,
        broth,
        hunk_of_meat,
		cabbage
	}

    public enum FoodDescriptions
    {
        tasty,
        frozen,
        warm,
        disgusting,
        maggot_ridden,
        succulent
    }


	public enum MonsterDescriptions
    {
        scaley,
        slimey,
        wicked,
        aggressive,
        small,
        large,
        dozy,
        sleepy,
        angry,
        ghastly
    }

    public enum MonsterKinds
    {
        balrog,
        warthog,
        serpent,
        ringwraith,
        troll,
        goblin,
        dwarf,
        elf
    }

    public enum Descriptions
    {
        none,
        dirty,
        sharp,
        shiny,
        small,
        large,
        blunt,
        broken,
        bloody
    }

    public enum WeatherContent
    {
        ClearSky,
        Fog
    }

}
