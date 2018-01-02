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
        spin_the_wheel,
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
        goblet,
        decorative_dagger,
        necklace,
        head_dress,
        shoe,
        belt
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
		cabbage,
        potato,
        cake,
        loaf_of_bread,
        leg_of_chicken,
        rib_of_meat,
        chicken_breast,
        onion
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
        mouldy,
        worm_infested,
        fresh,
        stinking,
        ponging,
        reeking,
        rotten
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
        snarling,
        ferocious,
        evil,
        cruel,
        corpulent,
        diseased,
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
        demon_horse,
        dwarf,
        elf,
        wraith,
        giant_lizard,
        vulture,
        giant_spider,
        giant_rat,
        wild_cat                                                                                  ,
        wolf,
        grizzly_bear,
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
