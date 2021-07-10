using System.Linq;
using MealsMvc.Models;

namespace MealsMvc.Data
{
    public class DbInitializer
    {
        public static void Initialize(MealsMvcContext context)
        {
            // Look for any students.
            if (context.MealPlans.Any())
            {
                return;   // DB has been seeded
            }

            var steps = new Step[]
            {
                new Step { Name = "Bring pot small pot of water to a boil, add lentils, boil at med-hi for 10 min, then drain" },
                new Step { Name = "Saute onion and mushrooms 5 mins" },

            };

            var cup = new SizeType { Name = "cup" };
            var clove = new SizeType { Name = "clove" };
            var tsp = new SizeType { Name = "tsp" };
            var bag = new SizeType { Name = "bag" };
            var can = new SizeType { Name = "can" };
            var each = new SizeType { Name = "each" };
            var ounce = new SizeType { Name = "ounce" };
            var TB = new SizeType { Name = "TB" };
            var lb = new SizeType { Name = "lb" };
            var head = new SizeType { Name = "head" };

            var sizeTypes = new SizeType[]
            {
                cup,
                new SizeType { Name = "TB" },
                tsp,
                new SizeType { Name = "ou" },
                lb,
                clove,
                bag,
                can,
                each,
                head
            };
            context.SizeTypes.AddRange(sizeTypes);
            context.SaveChanges();

            var chop = new PrepType { Name = "chop" };
            var noprep = new PrepType { Name = "No prep" };
            var steam = new PrepType { Name = "steam" };
            var precook = new PrepType { Name = "cook grains" };
            var drain = new PrepType { Name = "drain and rinse" };
            var thaw = new PrepType { Name = "thaw" };
            var grated = new PrepType { Name = "grated" };
            var roast = new PrepType { Name = "roast" };
            var blend = new PrepType { Name = "blend" };
            var bake = new PrepType { Name = "bake" };
            var shred = new PrepType { Name = "shred" };

            var prepTypes = new PrepType[]
            {
                noprep,
                chop,
                steam,
                precook,
                thaw,
                new PrepType { Name = "cook beans" },
                new PrepType { Name = "make sauce" },
                grated,
                roast,
                blend,
                bake,
                shred
            };
            context.PrepTypes.AddRange(prepTypes);
            context.SaveChanges();

            var grainsBeans = new GroceryAisle { Name = "Grains/Beans" };
            var produce = new GroceryAisle { Name = "Produce" };
            var spices = new GroceryAisle { Name = "Spices" };
            var canned = new GroceryAisle { Name = "Canned goods" };
            var frozen = new GroceryAisle { Name = "Frozen" };
            var condiments = new GroceryAisle { Name = "Condiments" };
            var dairy = new GroceryAisle { Name = "Dairy" };

            var groceryAisles = new GroceryAisle[]
            {
                produce,
                grainsBeans,
                condiments,
                new GroceryAisle { Name = "Plant milk" },
                frozen,
                canned,
                spices,
                dairy
            };
            context.GroceryAisles.AddRange(groceryAisles);
            context.SaveChanges();

            var lentils = new Food { Name = "lentils", GroceryAisle = grainsBeans, CookedCupsConversion = 2.5 };
            var basmati = new Food { Name = "basmati rice", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var garlic = new Food { Name = "garlic", GroceryAisle = produce };
            var onions = new Food { Name = "onion", GroceryAisle = produce, CookedCupsConversion = 0.3 };
            var stock = new Food { Name = "vegetable stock", GroceryAisle = canned };
            var cuminseeds = new Food { Name = "cumin seeds", GroceryAisle = spices };
            var cumin = new Food { Name = "cumin", GroceryAisle = spices };
            var mushrooms = new Food { Name = "mushrooms", GroceryAisle = produce };
            //staples
            var frozengreenbeans = new Food { Name = "frozen green beans", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var frozenbroc = new Food { Name = "frozen broccoli", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var biggreens = new Food { Name = "2 lb greens", GroceryAisle = produce, CookedCupsConversion = 8 };
            var broccolibag = new Food { Name = "broccoli", GroceryAisle = produce, CookedCupsConversion = 8 };
            var poundgreens = new Food { Name = "1 lb greens", GroceryAisle = produce, CookedCupsConversion = 6 };
            var frozenPeppers = new Food { Name = "12 oz frozen pepper/onion", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var frozenCauliflower = new Food { Name = "12 oz frozen cauliflower", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var frozenVeg = new Food { Name = "veg (any)", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var anyCookedGrain = new Food { Name = "cooked grains (any)", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var anyCannedBeans = new Food { Name = "canned beans (any)", GroceryAisle = grainsBeans, CookedCupsConversion = 3 };
            var frozenPeas = new Food { Name = "12 oz frozen peas", GroceryAisle = frozen, CookedCupsConversion = 3 };
            var canTomatoes = new Food { Name = "16 ou tomatoes", GroceryAisle = canned, CookedCupsConversion = 2 };
            var canBlackBeans = new Food { Name = "black beans", GroceryAisle = canned, CookedCupsConversion = 2 };
            var greenPeppers = new Food { Name = "green pepper", GroceryAisle = produce };
            var chiliPowder = new Food { Name = "chili powder", GroceryAisle = spices };
            var curry = new Food { Name = "curry powder", GroceryAisle = spices };
            var coriander = new Food { Name = "coriander", GroceryAisle = spices };
            var appleCiderVinegar = new Food { Name = "apple cider vinegar", GroceryAisle = condiments };
            var carrot = new Food { Name = "carrot", GroceryAisle = produce };
            var collardGreens = new Food { Name = "collard greens", GroceryAisle = produce };
            var cookedQuinoa = new Food { Name = "cooked quinoa", GroceryAisle = grainsBeans };
            var corn = new Food { Name = "corn", GroceryAisle = frozen };
            var freshGinger = new Food { Name = "fresh ginger", GroceryAisle = produce };
            var garlicPowder = new Food { Name = "garlic powder", GroceryAisle = spices };
            var greenOnions = new Food { Name = "green onions", GroceryAisle = produce };
            var kale = new Food { Name = "kale", GroceryAisle = produce };
            var kidneyBeans = new Food { Name = "kidney beans", GroceryAisle = grainsBeans };
            var mapleSyrup = new Food { Name = "maple syrup", GroceryAisle = condiments };
            var redPepper = new Food { Name = "red pepper", GroceryAisle = produce };
            var napaCabbage = new Food { Name = "napa cabbage", GroceryAisle = produce };
            var riceVinegar = new Food { Name = "rice vinegar", GroceryAisle = condiments };
            var salsaVerde = new Food { Name = "salsa verde", GroceryAisle = condiments };
            var smallTomato = new Food { Name = "small tomato", GroceryAisle = produce };
            var sweetPotato = new Food { Name = "sweet potato", GroceryAisle = produce };
            var tahini = new Food { Name = "tahini", GroceryAisle = condiments };
            var toastedSesameSeeds = new Food { Name = "toasted sesame seeds", GroceryAisle = condiments };
            var tamari = new Food { Name = "tamari", GroceryAisle = condiments };
            var yellowSquash = new Food { Name = "yellow squash", GroceryAisle = produce };
            var celery = new Food { Name = "celery", GroceryAisle = produce };
            var thyme = new Food { Name = "thyme", GroceryAisle = spices };
            var broccoli = new Food { Name = "broccoli", GroceryAisle = produce };
            var caesar = new Food { Name = "caesar", GroceryAisle = condiments };
            var cheddarblock = new Food { Name = "cheddar block", GroceryAisle = dairy };
            var colbyjackblock = new Food { Name = "colbyjack block", GroceryAisle = dairy };
            var croutons = new Food { Name = "croutons", GroceryAisle = condiments };
            var frozenFruit = new Food { Name = "frozen fruit", GroceryAisle = frozen };
            var gratedparm = new Food { Name = "grated parm", GroceryAisle = dairy };
            var halfnhalf = new Food { Name = "half-n-half", GroceryAisle = dairy };
            var hashbrowns = new Food { Name = "hashbrowns", GroceryAisle = frozen };
            var milk = new Food { Name = "milk", GroceryAisle = dairy };
            var pasta = new Food { Name = "pasta", GroceryAisle = grainsBeans };
            var cucumber = new Food { Name = "cucumber", GroceryAisle = produce };
            var montereyblock = new Food { Name = "monterey block", GroceryAisle = dairy };
            var sausage = new Food { Name = "sausage", GroceryAisle = frozen };
            var spinach = new Food { Name = "spinach", GroceryAisle = produce };
            var velveeta = new Food { Name = "velveeta", GroceryAisle = dairy };
            var fruit = new Food { Name = "fruit", GroceryAisle = produce };
            var russetPotato = new Food { Name = "russet potato", GroceryAisle = produce };
            var cranberries = new Food { Name = "cranberries", GroceryAisle = grainsBeans };
            var saladgreens = new Food { Name = "salad greens", GroceryAisle = produce };
            var sunflowerseeds = new Food { Name = "sunflowerseeds", GroceryAisle = grainsBeans };
            var redonion = new Food { Name = "red onion", GroceryAisle = produce };
            var whitetortilla = new Food { Name = "white tortilla", GroceryAisle = grainsBeans };
            var refriedbeans = new Food { Name = "refried beans", GroceryAisle = canned };
            var gratedcheddar = new Food { Name = "grated cheddar", GroceryAisle = dairy };
            var gratedmozz = new Food { Name = "grated mozz", GroceryAisle = dairy };

            var foods = new Food[]
            {
                lentils,
                basmati,
                garlic,
                onions,
                mushrooms,
                stock,
                cumin,
                frozengreenbeans,
                frozenbroc,
                biggreens,
                broccolibag,
                poundgreens,
                frozenPeppers,
                canTomatoes,
                canBlackBeans,
                greenPeppers,
                chiliPowder,
                coriander,
                salsaVerde,
                appleCiderVinegar,
                smallTomato,
                yellowSquash,
                greenOnions,
                napaCabbage,
                corn,
                cookedQuinoa,
                kidneyBeans,
                carrot,
                redPepper,
                riceVinegar,
                tahini,
                tamari,
                mapleSyrup,
                freshGinger,
                garlicPowder,
                toastedSesameSeeds,
                kale,
                sweetPotato,
                collardGreens,
                celery,
                thyme
            };
            context.Foods.AddRange(foods);
            context.SaveChanges();

            var ingredLentils = new Ingredient { Food = lentils, PrepType = noprep, Size = 0.5, SizeType = cup };
            var ingredOnions = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeType = cup };
            var ingredOnions1 = new Ingredient { Food = onions, PrepType = chop, Size = 0.5, SizeType = cup };
            var ingredMushrooms = new Ingredient { Food = mushrooms, PrepType = chop, Size = .5, MaxSize=1, SizeType = lb, Optional=true };
            var ingredGarlic = new Ingredient { Food = garlic, PrepType = chop, Size = 1, SizeType = clove };
            var ingredStock = new Ingredient { Food = stock, PrepType = noprep, Size = 2, SizeType = cup };
            var ingredCumin = new Ingredient { Food = cuminseeds, PrepType = noprep, Size = .5, SizeType = tsp };
            var ingredBasmati = new Ingredient { Food = basmati, PrepType = noprep, Size = 2, SizeType = cup };
            var ingredBlackBeans = new Ingredient { Food = canBlackBeans, PrepType = noprep, Size = 1, SizeType = can };
            var ingredCanTomatoes = new Ingredient { Food = canTomatoes, PrepType = noprep, Size = 1, SizeType = can };
            var ingredBlackBeans1 = new Ingredient { Food = canBlackBeans, PrepType = noprep, Size = 1, SizeType = can };
            var ingredCanTomatoes1 = new Ingredient { Food = canTomatoes, PrepType = noprep, Size = 1, SizeType = can };
            var ingredCanTomatoes2 = new Ingredient { Food = canTomatoes, PrepType = noprep, Size = 1, SizeType = can };
            var ingredPeppers = new Ingredient { Food = greenPeppers, PrepType = chop, Size = 1, SizeType = each };
            var ingredFrozenPeppers = new Ingredient { Food = frozenPeppers, PrepType = noprep, Size = 1, SizeType = bag };
            var ingredFrozenCauliflower = new Ingredient { Food = frozenCauliflower, PrepType = noprep, Size = 1, SizeType = bag };
            var ingredAnyFrozenVeg = new Ingredient { Food = frozenVeg, PrepType = noprep, Size = 6, SizeType = ounce };
            //veg, grain - on recipe, show as cup, in grocery list show as ounces. beans - recipe: cup, grocery: can
            var ingredAnyGrain = new Ingredient { Food = anyCookedGrain, PrepType = precook, Size = 1, SizeType = cup };
            var ingredAnyBeans = new Ingredient { Food = anyCannedBeans, PrepType = drain, Size = .25, SizeType = can };
            var ingredFrozenPeas = new Ingredient { Food = frozenPeas, PrepType = noprep, Size = .25, SizeType = cup };
            var ingredChiliCumin = new Ingredient { Food = cumin, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredChilipowder = new Ingredient { Food = chiliPowder, PrepType = noprep, Size = 4, SizeType = tsp };
            var ingredChilipowder1 = new Ingredient { Food = chiliPowder, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredCurry = new Ingredient { Food = curry, PrepType = noprep, Size = 1, SizeType = tsp };
            var ingredCoriander = new Ingredient { Food = coriander, PrepType = noprep, Size = .5, SizeType = tsp };
            var ingredSalsaVerde = new Ingredient { Food = salsaVerde, PrepType = noprep, Size = .75, SizeType = cup };
            var ingredapplecidervinegar = new Ingredient { Food = appleCiderVinegar, PrepType = noprep, Size = 2, SizeType = tsp };
            var ingredsmallTomato = new Ingredient { Food = smallTomato, PrepType = chop, Size = 1, SizeType = each };
            var ingredyellowSquash = new Ingredient { Food = yellowSquash, PrepType = chop, Size = 1, SizeType = each };
            var ingredgreenOnions = new Ingredient { Food = greenOnions, PrepType = chop, Size = 4, SizeType = each };
            var ingrednapaCabbage = new Ingredient { Food = napaCabbage, PrepType = chop, Size = 2, SizeType = cup };
            var ingredcorn = new Ingredient { Food = corn, PrepType = noprep, Size = .5, SizeType = cup };
            var ingredcookedQuinoa = new Ingredient { Food = cookedQuinoa, PrepType = noprep, Size = .5, SizeType = cup };
            var ingredkidneyBeans = new Ingredient { Food = kidneyBeans, PrepType = noprep, Size = .5, SizeType = cup };
            var ingredcookedQuinoa2 = new Ingredient { Food = cookedQuinoa, PrepType = noprep, Size = 2, SizeType = cup };
            var ingredPeas2 = new Ingredient { Food = frozenPeas, PrepType = thaw, Size = .5, SizeType = cup };
            var ingredCarrot = new Ingredient { Food = carrot, PrepType = grated, Size = .5, SizeType = cup };
            var ingredredPepper = new Ingredient { Food = redPepper, PrepType = chop, Size = .25, SizeType = cup };
            var ingredgreenOnions2 = new Ingredient { Food = greenOnions, PrepType = chop, Size = 1, SizeType = TB };
            var ingredriceVinegar = new Ingredient { Food = riceVinegar, PrepType = noprep, Size = 3, SizeType = TB };
            var ingredTahini = new Ingredient { Food = tahini, PrepType = noprep, Size = 1.5, SizeType = TB };
            var ingredTamari = new Ingredient { Food = tamari, PrepType = noprep, Size = 2, SizeType = TB };
            var ingredMapleSyrup = new Ingredient { Food = mapleSyrup, PrepType = noprep, Size = 1.5, SizeType = TB };
            var ingredginger = new Ingredient { Food = freshGinger, PrepType = grated, Size = 1, SizeType = tsp };
            var ingredgarlicpowder = new Ingredient { Food = garlicPowder, PrepType = grated, Size = .25, SizeType = tsp };
            var ingredtoastedSesameseeds = new Ingredient { Food = toastedSesameSeeds, PrepType = grated, Size = 1, SizeType = TB };
            var ingredMushrooms1 = new Ingredient { Food = mushrooms, PrepType = chop, Size = .5, MaxSize=1, SizeType = lb, Optional = true };
            var ingredCarrots1   = new Ingredient { Food = carrot, PrepType = chop, Size = 2, SizeType = each };
            var ingredCelery = new Ingredient { Food = celery, PrepType = chop, Size = 1, SizeType = each };
            var ingredLentils1 = new Ingredient { Food = lentils, PrepType = noprep, Size = 1, SizeType = cup };
            var ingredOnions2 = new Ingredient { Food = onions, PrepType = chop, Size = 1, SizeType = cup };
            var ingredGarlic2 = new Ingredient { Food = garlic, PrepType = chop, Size = 2, SizeType = clove };
            var ingredThyme = new Ingredient { Food = thyme, PrepType = noprep, Size = 1, SizeType = tsp };
            var ingredCheddarBlock = new Ingredient { Food = cheddarblock, PrepType = grated, Size = 1, SizeType = tsp };
            var ingredMontereyBlock = new Ingredient { Food = montereyblock, PrepType = grated, Size = 1, SizeType = tsp };
            var ingredColbyJackBlock = new Ingredient { Food = colbyjackblock, PrepType = grated, Size = 1, SizeType = tsp };
            var ingredVelveeta = new Ingredient { Food = velveeta, PrepType = grated, Size = 1, SizeType = tsp };
            var ingredGratedParm = new Ingredient { Food = gratedparm, PrepType = noprep, Size = 1, SizeType = tsp };
            var ingredPasta = new Ingredient { Food = pasta, PrepType = noprep, Size = 6, SizeType = ounce };
            var ingredMilk = new Ingredient { Food = milk, PrepType = noprep, Size = 1, SizeType = tsp };
            var ingredCarrotSticks = new Ingredient { Food = carrot, PrepType = chop, Size = 1, SizeType = cup };
            var ingredCucumberSticks = new Ingredient { Food = cucumber, PrepType = chop, Size = 1, SizeType = cup };
            var ingredCollards = new Ingredient { Food = collardGreens, PrepType = steam, Size = 2, SizeType = lb };
            var ingredSweetPotatoes = new Ingredient { Food = sweetPotato, PrepType = roast, Size = 8, SizeType = each };
            var ingredSpinach = new Ingredient { Food = spinach, PrepType = noprep, Size = 6, SizeType = ounce };
            var ingredCaesar = new Ingredient { Food = caesar, PrepType = noprep, Size = 2, SizeType = TB };
            var ingredGratedParm1 = new Ingredient { Food = gratedparm, PrepType = noprep, Size = 1, SizeType = TB };
            var ingredCroutons = new Ingredient { Food = croutons, PrepType = noprep, Size = 2, SizeType = TB };
            var ingredPasta1 = new Ingredient { Food = pasta, PrepType = noprep, Size = 6, SizeType = ounce };
            var ingredHalfnHalf = new Ingredient { Food = halfnhalf, PrepType = noprep, Size = .5, SizeType = cup };
            var ingredGratedParm2 = new Ingredient { Food = gratedparm, PrepType = steam, Size = .5, SizeType = cup };
            var ingredBroccoli = new Ingredient { Food = broccoli, PrepType = steam, Size = 2, SizeType = head };
            var ingredFrozenFruit = new Ingredient { Food = frozenFruit, PrepType = blend, Size = 6, SizeType = ounce };
            var ingredHashbrowns = new Ingredient { Food = hashbrowns, PrepType = blend, Size = 1, SizeType = lb };
            var ingredOnions3 = new Ingredient { Food = sausage, PrepType = blend, Size = 3, SizeType = ounce };
            var ingredSausage = new Ingredient { Food = onions, PrepType = blend, Size = .5, SizeType = each };
            var ingredChoppedCarrots = new Ingredient { Food = onions, PrepType = chop, Size = 2, SizeType = cup };
            var ingredFruit = new Ingredient { Food = fruit, PrepType = noprep, Size = 4, SizeType = each };
            var ingredChoppedCucumber = new Ingredient { Food = cucumber, PrepType = chop, Size = 2, SizeType = cup };
            var ingredChoppedRedPepper = new Ingredient { Food = redPepper, PrepType = chop, Size = 2, SizeType = cup };
            var ingredPotatoes = new Ingredient { Food = russetPotato, PrepType = bake, Size = 6, SizeType = each };
            var ingredSaladGreens = new Ingredient { Food = saladgreens, PrepType = noprep, Size = 12, SizeType = ounce };
            var ingredShreddedCarrots = new Ingredient { Food = carrot, PrepType = shred, Size = 1, SizeType = each };
            var ingredSunflowerSeeds = new Ingredient { Food = sunflowerseeds, PrepType = noprep, Size = 2, SizeType = ounce };
            var ingredCranberries = new Ingredient { Food = cranberries, PrepType = noprep, Size = 2, SizeType = ounce };
            var ingredCucumber = new Ingredient { Food = cucumber, PrepType = chop, Size = 1, SizeType = each };
            var ingredChoppedPepper = new Ingredient { Food = redPepper, PrepType = chop, Size = 1, SizeType = each };
            var ingredRedOnion = new Ingredient { Food = redonion, PrepType = chop, Size = .25, SizeType = each };
            var ingredTortillas = new Ingredient { Food = whitetortilla, PrepType = noprep, Size = 4, SizeType = each };
            var ingredRefriedBeans = new Ingredient { Food = redonion, PrepType = chop, Size = .25, SizeType = each };
            var ingredGratedMozz = new Ingredient { Food = gratedmozz, PrepType = noprep, Size = 2, SizeType = ounce };
            var ingredGratedCheddar = new Ingredient { Food = gratedcheddar, PrepType = noprep, Size = 2, SizeType = ounce };
            var ingredCucumberSticks1 = new Ingredient { Food = cucumber, PrepType = chop, Size = 1, SizeType = each };
            var ingredCarrotSticks1 = new Ingredient { Food = carrot, PrepType = chop, Size = 2, SizeType = each };

            var quesadillas = new Ingredient[]
            {
                ingredTortillas,
                ingredRefriedBeans,
                ingredGratedMozz,
                ingredGratedCheddar,
                ingredCucumberSticks1,
                ingredCarrotSticks1
            };

            var MikeSalad = new Ingredient[]
            {
                ingredSaladGreens,
                ingredShreddedCarrots,
                ingredSunflowerSeeds,
                ingredCranberries,
                ingredCucumber,
                ingredChoppedPepper,
                ingredRedOnion
            };

            var hashbrownsRecipe = new Ingredient[]
            {
                ingredHashbrowns,
                ingredOnions3,
                ingredSausage
            };

            var smoothie = new Ingredient[]
            {
                ingredFrozenFruit
            };

            var alfredo = new Ingredient[]
            {
                ingredPasta1,
                ingredHalfnHalf,
                ingredGratedParm2,
                ingredBroccoli
            };

            var spinachSalad = new Ingredient[]
            {
                ingredSpinach,
                ingredCaesar,
                ingredGratedParm1,
                ingredCroutons
            };

            var macncheese = new Ingredient[]
            {
                ingredCheddarBlock,
                ingredMontereyBlock,
                ingredColbyJackBlock,
                ingredVelveeta,
                ingredGratedParm,
                ingredPasta,
                ingredMilk,
                ingredCarrotSticks,
                ingredCucumberSticks
            };

            var frenchLentils = new Ingredient[]
            {
                ingredMushrooms1,
                ingredCarrots1,
                ingredCelery,
                ingredLentils1,
                ingredOnions2,
                ingredGarlic2,
                ingredThyme
            };

            var sesamequinoaSalad = new Ingredient[]
           {
                ingredcookedQuinoa2,
                ingredPeas2,
                ingredCarrot,
                ingredredPepper,
                ingredgreenOnions2,
                ingredriceVinegar,
                ingredTahini,
                ingredTamari,
                ingredMapleSyrup,
                ingredginger,
                ingredgarlicpowder,
                ingredtoastedSesameseeds
           };

            var redbeanSalad = new Ingredient[]
            {
                ingredSalsaVerde,
                ingredapplecidervinegar,
                ingredsmallTomato,
                ingredyellowSquash,
                ingredgreenOnions,
                ingrednapaCabbage,
                ingredcorn,
                ingredcookedQuinoa,
                ingredkidneyBeans
            };

            var snapIngreds = new Ingredient[]
            {
                ingredCanTomatoes,
                ingredFrozenPeppers,
                ingredBlackBeans,
                ingredChilipowder1
            };

            var snapIndianIngreds = new Ingredient[]
            {
                ingredCanTomatoes2,
                ingredFrozenCauliflower,
                ingredFrozenPeas,
                ingredCurry
            };

            var snapBowlIngreds = new Ingredient[]
            {
                ingredAnyFrozenVeg,
                ingredAnyGrain,
                ingredAnyBeans
            };

            var chiliIngreds = new Ingredient[]
            {
                ingredBlackBeans1,
                ingredCanTomatoes1,
                ingredOnions,
                ingredPeppers,
                ingredChiliCumin,
                ingredChilipowder,
                ingredCoriander,
                ingredCollards,
                ingredSweetPotatoes
            };

            var PotatoSnacks = new Ingredient[]
            {
                ingredPotatoes
            };

            var VeggieSnacks = new Ingredient[]
            {
                ingredChoppedCarrots,
                ingredChoppedCucumber,
                ingredChoppedRedPepper,
            };

            var FruitSnacks = new Ingredient[]
            {
                ingredFruit
            };

            var lentilRiceIngreds = new Ingredient[] {
                ingredLentils,
                ingredOnions1,
                ingredGarlic,
                ingredMushrooms,
                ingredStock,
                ingredCumin,
                ingredBasmati
            };

            var recipes = new Recipe[]
            {
                new Recipe{Name="Lentils & Rice", Steps = steps, Ingredients = lentilRiceIngreds, ImageUrl = "~/images/lentilsandrice.jpg", NumberServings = 6, VegServingsMissing=1, PercentForYou=.5},
                new Recipe{Name="Black bean chili", Ingredients = chiliIngreds, ImageUrl = "~/images/chili.jpg", NumberServings = 8, GrainServingsMissing=1, VegServingsMissing=1, PercentForYou=.75},
                //new Recipe{Name="Pinto bean chili"},
                //new Recipe{Name="Peanut stir-fry"},
                new Recipe{Name="French lentils", Ingredients = frenchLentils, ImageUrl = "~/images/frenchlentils.jpg", NumberServings = 8, VegServingsMissing=1},
                new Recipe{Name="Quick Mexican", Ingredients= snapIngreds, ImageUrl="~/images/beansrice.jpg", NumberServings=4},
                new Recipe{Name="Quick Indian", Ingredients= snapIndianIngreds, ImageUrl="~/images/indianSNAP.jpg", NumberServings=4},
                new Recipe{Name="Quick bowl", Ingredients= snapBowlIngreds, ImageUrl="~/images/beansricegreens.jpg", NumberServings=1},
                new Recipe{Name="Quinoa and Red Bean Salad", Ingredients=redbeanSalad, ImageUrl="~/images/quinoaredbean.jpg", NumberServings=2 },
                new Recipe{Name="Sesame Quinoa Salad", Ingredients=sesamequinoaSalad, ImageUrl="~/images/sesamequinoasalad.jpg", NumberServings=2 },
                new Recipe{Name="Mac & Cheese", Ingredients=macncheese, ImageUrl="~/images/bakedmac.jpg", NumberServings=2},
                new Recipe{Name="Spinach Salad", Ingredients=spinachSalad, ImageUrl="~/images/spinachsalad.jpg", NumberServings=1},
                new Recipe{Name="Alfredo", Ingredients=alfredo, ImageUrl="~/images/alfredo.jpg", NumberServings=2},
                new Recipe{Name="Smoothie", Ingredients=smoothie, ImageUrl="~/images/smoothie.jpg", NumberServings=1},
                new Recipe{Name="Hashbrowns", Ingredients=hashbrownsRecipe, ImageUrl="~/images/hashbrowns.jpg", NumberServings=1},
                new Recipe{Name="Potato snacks", Ingredients=PotatoSnacks, ImageUrl="~/images/potatoes.jpg", NumberServings=4},
                new Recipe{Name="Veggie snacks", Ingredients=VeggieSnacks, ImageUrl="~/images/cucumbercarrots.jpg", NumberServings=4},
                new Recipe{Name="Fruit", Ingredients=FruitSnacks, ImageUrl="~/images/fruit.jpg", NumberServings=4},
                new Recipe{Name="Mike Salad", Ingredients=MikeSalad, ImageUrl="~/images/mikesalad.jpg", NumberServings=4},
                new Recipe{Name="Quesadillas", Ingredients=quesadillas, ImageUrl="~/images/quesadillas.jpg", NumberServings=2}
            };

            context.Recipes.AddRange(recipes);
            context.SaveChanges();

            var mealPlans = new MealPlan[]
                {
                new MealPlan{Name="The Usual"},
                new MealPlan{Name="Mexican"},
                new MealPlan{Name="Asian"},
                };

            context.MealPlans.AddRange(mealPlans);
            context.SaveChanges();

            var mealPlanRecipes = new MealPlanRecipe[]
            {
                new MealPlanRecipe{RecipeID=1,MealPlanID=1,NumberBatches=2},
                new MealPlanRecipe{RecipeID=1,MealPlanID=2},
                new MealPlanRecipe{RecipeID=1,MealPlanID=3},
                new MealPlanRecipe{RecipeID=2,MealPlanID=2},
                new MealPlanRecipe{RecipeID=2,MealPlanID=3,NumberBatches=2},
                new MealPlanRecipe{RecipeID=3,MealPlanID=3},
                new MealPlanRecipe{RecipeID=3,MealPlanID=1,NumberBatches=3},
                new MealPlanRecipe{RecipeID=3,MealPlanID=2},
                new MealPlanRecipe{RecipeID=4,MealPlanID=1},
                new MealPlanRecipe{RecipeID=4,MealPlanID=2},
                new MealPlanRecipe{RecipeID=4,MealPlanID=3},
            };

            context.MealPlanRecipes.AddRange(mealPlanRecipes);
            context.SaveChanges();

            var userSettings = new UserSettings[]
            {
                new UserSettings{MealPlanID=1 }
            };

            context.UserSettings.AddRange(userSettings);
            context.SaveChanges();
        }
    }
}
