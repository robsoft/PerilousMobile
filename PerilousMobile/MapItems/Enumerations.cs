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
        reflex_test,
        riddle,
        sum
    }

    public enum PuzzleDescriptions
    {
        nasty,
        tricky,
        easy,
        trivial,
        impossible
    }


    public enum WeaponKinds
    {
        sword,
        dagger,
        axe,
        knife,
        broadsword,
        hammer,
        catapult
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
        broken,
        damaged,
        elegant,
    }

    public enum LootKinds
    {
        ring,
        bottle,
        pendant,
        chain,
        locket,
        crown,
        braclet,
        plate,
        goblet
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
        succulent,
        grimy,
        soggy,
        part_cooked,
        part_eaten,
        regurgitated,
        mouldy
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
        ghastly,
        worrisome,
        sad,
        vicious,
        violent,
        furious,
        confused,
        cunning,
        devious,
        bloody,
        wretched,
        obnoxious,
        flatulent,
        obese,
        dizzy
    }

    public enum MonsterKinds
    {
        balrog,
        warthog,
        serpent,
        ring_wraith,
        troll,
        goblin,
        dwarf,
        elf,
        wraith,
        giant_lizard,
        vulture,
        giant_spider,
        giant_rat,
        wild_feline,
        wolf,
        giant_parasite_worm
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


    public enum PrincessDescriptions
    {
        kind,
        voluptuous,
        buxom,
        sarcastic,
        withering,
        hearty,
        snivelling,
        angry,
        fearful,
        brave,
        cowardly,
        cunning,
        upset,
        bemused,
        grateful
    }

    public enum WeatherContent
    {
        ClearSky,
        Fog
    }

}
