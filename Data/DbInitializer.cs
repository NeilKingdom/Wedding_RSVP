using Wedding_RSVP.Models;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Wedding_RSVP.Data
{
   public static class DbInitializer
   {
      public static void Initialize(WeddingDbContext context)
      {
         context.Database.EnsureCreated();

         if (context.Users.Any())
         {
            return; // DB has been seeded
         }

         // Add users to DB
         var users = new List<User>
         {
            new User { FirstName="John",  LastName="Doe",   Email="john@example.com",  NumAttendees=1 }
         };
         users.ForEach(user => context.Users.Add(user));
         context.SaveChanges();

         // Add Gifts to DB
         var gifts = new List<Gift>
         {
            new Gift {
               ImgUrl="~/img/thumbnails/CookingUtensils_33KitchenGadgets.jpg",
               SiteUrl="https://www.amazon.ca/Set-Silicone-Utensils-33-Cookware-Silicone-Stainless-Accessories/dp/B089FBYT3W/ref=sr_1_1?crid=2Z1HNXJ9PCGQH&keywords=Kitchen+Utensil+Set-Silicone+Cooking+Utensils-33+Kitchen+Gadgets+%26+Spoons+for+Nonstick+Cookware-&qid=1673710536&sprefix=kitchen+utensil+set-silicone+cooking+utensils-33+kitchen+gadgets+%26+spoons+for+nonstick+cookware-%2Caps%2C58&sr=8-1",
               EstPrice=67.79,
               Desc="Kitchen Utensil Set-Silicone Cooking Utensils",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/KitchenCuttingBoard.jpg",
               SiteUrl="https://www.amazon.ca/HOMWE-Easy-Grip-BPA-Free-Non-Porous-Dishwasher/dp/B07R298N1Q/ref=sr_1_2?crid=3S9PW2Q5N1YXZ&keywords=HOMWE+Kitchen+Cutting+Board+%283-Piece+Set%29+%7C+Juice+Grooves+w%2FEasy-Grip+Handles+%7C+BPA-Free%2C+Non-Porous%2C+Dishwasher+Safe+%7C+Multiple+Sizes+%28Set+of+Three%2C+Black%29&qid=1673710831&s=kitchen&sprefix=homwe+kitchen+cutting+board+3-piece+set+juice+grooves+w%2Feasy-grip+handles+bpa-free%2C+non-porous%2C+dishwasher+safe+multiple+sizes+set+of+three%2C+black+%2Ckitchen%2C59&sr=1-://www.amazon.ca/HOMWE-Easy-Grip-BPA-Free-Non-Porous-Dishwasher/dp/B07R298N1Q/ref=sr_1_2?crid=3S9PW2Q5N1YXZ&keywords=HOMWE+Kitchen+Cutting+Board+%283-Piece+Set%29+%7C+Juice+Grooves+w%2FEasy-Grip+Handles+%7C+BPA-Free%2C+Non-Porous%2C+Dishwasher+Safe+%7C+Multiple+Sizes+%28Set+of+Three%2C+Black%29&qid=1673710831&s=kitchen&sprefix=homwe+kitchen+cutting+board+3-piece+set+juice+grooves+w%2Feasy-grip+handles+bpa-free%2C+non-porous%2C+dishwasher+safe+multiple+sizes+set+of+three%2C+black+%2Ckitchen%2C59&sr=1-2",
               EstPrice=23.99,
               Desc="Kitchen Cutting Board",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/SquareDinnerware.jpg",
               SiteUrl="https://www.amazon.ca/AmazonBasics-18-Piece-Dinnerware-Set-Service/dp/B07FJ91KN5/ref=sr_1_1?crid=7POHJZN1ICXP&keywords=Amazon+Basics+18-Piece+Square+Kitchen+Dinnerware+Set%2C+Dishes%2C+Bowls%2C+Service+for+6%2C+Modern+Beams&qid=1673711041&s=kitchen&sprefix=amazon+basics+18-piece+square+kitchen+dinnerware+set%2C+dishes%2C+bowls%2C+service+for+6%2C+modern+beams%2Ckitchen%2C125&sr=1-1",
					EstPrice=79.90,
               Desc="Square Kitchen Dinnerware Set",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/MixingBowlsWithLids.jpg",
               SiteUrl="https://www.amazon.ca/Airtight-Stainless-Umite-Chef-Non-Slip/dp/B08THF9J8S/ref=sr_1_1?crid=3APJB4V0QO8M0&keywords=Mixing+Bowls+with+Airtight+Lids%EF%BC%8C6+Piece+Stainless+Steel+Metal+Nesting+Storage+Bowls+by+Umite+Chef%2C+Non-&qid=1673711238&s=kitchen&sprefix=mixing+bowls+with+airtight+lids+6+piece+stainless+steel+metal+nesting+storage+bowls+by+umite+chef%2C+non-%2Ckitchen%2C125&sr=1-1",
					EstPrice=47.99,
               Desc="Mixing Bowls with Airtight Lids",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/ColanderSetOfThree.jpg",
               SiteUrl="https://www.amazon.ca/CHEF-Stainless-Micro-Perforated-Vegetables-Dishwasher/dp/B07DXKRLXK/ref=sr_1_1?crid=1L87YF97OSMKQ&keywords=P%26P+CHEF+Colander+Set+of+3%2C+Stainless+Steel+Micro-Perforated+Colanders+Strainers+for+Draining+Rinsing+Washing%2C+Ideal+for+Pasta+Veg&qid=1673711364&s=kitchen&sprefix=p%26p+chef+colander+set+of+3%2C+stainless+steel+micro-perforated+colanders+strainers+for+draining+rinsing+washing%2C+ideal+for+pasta+veg%2Ckitchen%2C109&sr=1-1",
					EstPrice=34.99,
               Desc="Stainless Steel Colanders",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/DrinkingGlasses.jpg",
               SiteUrl="https://www.amazon.ca/Durable-Drinking-Glasses-16-Piece-Glassware/dp/B06Y17858J/ref=sr_1_1?crid=8A12EQT2T2G1&keywords=SET+OF+16+Heavy+Base+Ribbed+Durable+Drinking+Glasses+Includes+8+Cooler+Glasses+%2817oz%29+and+8+Rocks&qid=1673711472&s=kitchen&sprefix=set+of+16+heavy+base+ribbed+durable+drinking+glasses+includes+8+cooler+glasses+17oz+and+8+rocks+%2Ckitchen%2C75&sr=1-1",
					EstPrice=59.99,
               Desc="Heavy Base Ribbed Drinking Glasses",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/BritaWaterFilter.jpg",
               SiteUrl="https://www.amazon.ca/Brita-UltraMax-Water-Filter-Dispenser/dp/B07G3LV535/ref=sr_1_1?crid=1HCT0CF7QRD77&keywords=Brita+Extra+Large+27+Cup+Filtered+Water+Dispenser+with+2+Brita%E2%84%A2+Elite%E2%84%A2+Filters%2C+Made+Without+BPA%2C+UltraMax&qid=1673711606&s=kitchen&sprefix=brita+extra+large+27+cup+filtered+water+dispenser+with+2+brita+elite+filters%2C+made+without+bpa%2C+ultramax%2Ckitchen%2C133&sr=1-1",
					EstPrice=57.47,
               Desc="Brita Extra Large Filtered Water Dispenser",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/SiliconeOvenMitts.jpg",
               SiteUrl="https://www.amazon.ca/KATUMO-Silicone-Professional-Resistant-Potholder/dp/B08PQM2MPD/ref=sr_1_1?crid=VZOQ0VIGVS32&keywords=KATUMO+Silicone+Oven+Mitts%2C+Professional+466%E2%84%89+Heat+Resistant+Cooking+Gloves+Non+Slip+with+Soft&qid=1673711728&s=kitchen&sprefix=katumo+silicone+oven+mitts%2C+professional+466+heat+resistant+cooking+gloves+non+slip+with+soft+%2Ckitchen%2C66&sr=1-1",
					EstPrice=25.59,
               Desc="Silicone Oven Mitts",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/StainlessSteelCutlery.jpg",
               SiteUrl="https://www.amazon.ca/60-Piece-Silverware-Stainless-Restaurant-Dishwasher/dp/B07H7BYBYN/ref=sr_1_1?crid=69BQVR5TUK4&keywords=60-Piece+Cutlery+Flatware+Set+for+12%2C+LIANYU+Stainless+Steel+Home+Kitchen+Hotel+Restaurant+Silverware+Set%2C&qid=1673711790&s=kitchen&sprefix=60-piece+cutlery+flatware+set+for+12%2C+lianyu+stainless+steel+home+kitchen+hotel+restaurant+silverware+set%2C+%2Ckitchen%2C75&sr=1-1",
					EstPrice=66.99,
               Desc="Stainless Steel Cutlery Set",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/GlassStorage.jpg",
               SiteUrl="https://www.amazon.ca/Rubbermaid-Brilliance-Storage-Containers-Clear/dp/B08BR9HBZ3/ref=sr_1_1?crid=1JPZPD0V5SRLD&keywords=Rubbermaid+Brilliance+Glass+Storage+Set+of+9+Food+Containers+with+Lids+%2818+Pieces+Total%29%2C+Set%2C+Assorted%2C+Clear&qid=1673711922&s=kitchen&sprefix=rubbermaid+brilliance+glass+storage+set+of+9+food+containers+with+lids+18+pieces+total+%2C+set%2C+assorted%2C+clear+%2Ckitchen%2C83&sr=1-1",
					EstPrice=135.91,
               Desc="Rubbermaid Glass Container Set",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/TowelSet.jpg",
               SiteUrl="https://www.amazon.ca/Utopia-Towels-Black-8-Piece-Linen/dp/B09SP8HQT7/ref=sr_1_1?crid=3SVWBP67RZVJT&keywords=Utopia%2BTowels%2B-%2BTowel%2BSet%2C%2B2%2BBath%2BTowels%2C%2B2%2BHand%2BTowels%2C%2Band%2B4%2BWashcloths%2C%2B600%2BGSM%2BRing%2BSpun%2BCotton%2BHighly%2BAbsorbent%2BTowels%2Bfo&qid=1673711991&s=kitchen&sprefix=utopia%2Btowels%2B-%2Btowel%2Bset%2C%2B2%2Bbath%2Btowels%2C%2B2%2Bhand%2Btowels%2C%2Band%2B4%2Bwashcloths%2C%2B600%2Bgsm%2Bring%2Bspun%2Bcotton%2Bhighly%2Babsorbent%2Btowels%2Bfo%2Ckitchen%2C84&sr=1-1&th=1",
					EstPrice=135.72,
               Desc="Towel Set",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/CookwareSet.jpg",
               SiteUrl="https://www.walmart.ca/en/ip/t-fal-essential-8pc-cookware-set-black/6000199557233",
					EstPrice=76.97,
               Desc="Cookware Set",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/KnifeSet.jpg",
               SiteUrl="https://www.thebay.com/product/cuisinart-15-piece-forged-triple-riveted-knife-block-set-0600086583805.html?site_refer=AFF001&mid=43178&siteID=U9IWU2PurxM-YUwG6.cCN9RKDTFJXOmSTQ&utm_source=RAN&utm_medium=Affiliate&utm_campaign=Affiliate&ranMID=43178&ranEAID=U9IWU2PurxM&ranSiteID=U9IWU2PurxM-YUwG6.cCN9RKDTFJXOmSTQ",
					EstPrice=199.99,
               Desc="Knife Set",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/Toaster.jpg",
               SiteUrl="https://www.amazon.ca/Elite-Gourmet-ECT-3100-Functions-Stainless/dp/B09VYB4QYC/ref=sr_1_1?crid=2OFUGAJLS23JH&keywords=Elite+Gourmet+ECT-3100%23%23+Long+Slot+4+Slice+Toaster%2C+Reheat%2C+6+Toast+Settings%2C+Defrost%2C+Cancel+Functions%2C&qid=1673712377&s=kitchen&sprefix=elite+gourmet+ect-3100+long+slot+4+slice+toaster%2C+reheat%2C+6+toast+settings%2C+defrost%2C+cancel+functions%2C+%2Ckitchen%2C100&sr=1-1",
					EstPrice=46.77,
               Desc="4-Slot Toaster",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/HandBlender.jpg",
               SiteUrl="https://www.amazon.ca/KitchenAid-Variable-Corded-Blender-KHBV53OB/dp/B08F2TGH2M/ref=sr_1_3?crid=15HSWU89K5NKJ&keywords=KitchenAid+Variable+Speed+Corded+Hand+Blender%2C+Onyx+Black%2C+8+in+%28KHBV53OB%29&qid=1673712457&s=kitchen&sprefix=kitchenaid+variable+speed+corded+hand+blender%2C+onyx+black%2C+8+in+khbv53ob+%2Ckitchen%2C67&sr=1-3",
					EstPrice=89.99,
               Desc="Hand Blender",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/SaltAndPepper.jpg",
               SiteUrl="https://www.amazon.ca/Premium-Stainless-Salt-Pepper-Grinder/dp/B01N1PSWSB/ref=sr_1_1?crid=2HOSM5NO7ST4C&keywords=HOME+EC+Premium+Stainless+Steel+Salt+and+Pepper+Grinder+Set+of+2+-+Adjustable+Ceramic+Sea+Salt+Grinder+%26+Pepper+Grinder+-+Tall+Glass+Salt+and+Pepper+S&qid=1673712603&s=kitchen&sprefix=home+ec+premium+stainless+steel+salt+and+pepper+grinder+set+of+2+-+adjustable+ceramic+sea+salt+grinder+%26+pepper+grinder+-+tall+glass+salt+and+pepper+s%2Ckitchen%2C134&sr=1-1",
					EstPrice=24.99,
               Desc="Salt and Pepper Grinder",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/SpiceRack.jpg",
               SiteUrl="https://www.amazon.ca/DEFWAY-Revolving-Spice-Rack-Organizer/dp/B08QCCMGQX/ref=sr_1_1?crid=1YMADQCPB33Q5&keywords=DEFWAY+Revolving+Spice+Rack+Organizer+-+Stainless+Steel+Spice+Tower+with+20+Seasoning+Jars+and+Funnel%2C+Large+Standing+Cabine&qid=1673712686&s=kitchen&sprefix=defway+revolving+spice+rack+organizer+-+stainless+steel+spice+tower+with+20+seasoning+jars+and+funnel%2C+large+standing+cabine%2Ckitchen%2C84&sr=1-1",
					EstPrice=36.37,
               Desc="Revolving Spice Rack Organizer",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/CoffeeMaker.jpg",
               SiteUrl="https://www.amazon.ca/BLACK-DECKER-Programmable-Stainless-CM1231SC/dp/B07XTQ98BM/ref=sr_1_1?crid=2BGY6GP3K7WWN&keywords=BLACK+%2B+DECKER+12+Cup+Programmable+Coffee+Maker+in+Stainless+Steel%2C+CM1231SC&qid=1673712756&s=kitchen&sprefix=black+%2B+decker+12+cup+programmable+coffee+maker+in+stainless+steel%2C+cm1231sc%2Ckitchen%2C67&sr=1-1",
					EstPrice=74.99,
               Desc="Programmable Coffee Maker",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/Mixer.jpg",
               SiteUrl="https://www.amazon.ca/KitchenAid-KHM512BM-5-Speed-Ultra-Power/dp/B075SY1M6Z/ref=sr_1_1?crid=EEKZ5RY4CIGA&keywords=KitchenAid+KHM512BM+5+Speed+Hand+Mixer%2C+Black+Matte%2C+1+inch+count+of+3&qid=1673712858&s=kitchen&sprefix=kitchenaid+khm512bm+5+speed+hand+mixer%2C+black+matte%2C+1+inch+count+of+3+%2Ckitchen%2C92&sr=1-1",
					EstPrice=89.98,
               Desc="Hand Mixer",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/SwifferWetJet.jpg",
               SiteUrl="https://www.amazon.ca/Swiffer-Wetjet-Hardwood-Cleaner-Starter/dp/B07YQDD94M/ref=sr_1_1?crid=3U2PBU0ON7D5V&keywords=Swiffer+WetJet+Spray+Mop+Kit+%3A+Includes+1+Floor+Mop%2C+1+Bottle+of+Floor+Cleaner+Solution%2C+6+Heavy+Duty&qid=1673712924&s=kitchen&sprefix=swiffer+wetjet+spray+mop+kit+includes+1+floor+mop%2C+1+bottle+of+floor+cleaner+solution%2C+6+heavy+duty+%2Ckitchen%2C67&sr=1-1",
					EstPrice=36.09,
               Desc="Swiffer WetJet Mop Kit",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/FoodStorageContainers.jpg",
               SiteUrl="https://www.amazon.ca/Vtopmart-Container-Organizers-BPA-Free-Airtight/dp/B09CH69M56/ref=sr_1_1?crid=TWKBD541I9BI&keywords=Vtopmart+32pcs+Food+Storage+Container+Set%2C+Kitchen+%26+Pantry+Organizers+and+Storage%2C+BPA-Free+Plastic+Airtight+Food+Storage+Container+with+Lids+for+Cer&qid=1673713018&s=kitchen&sprefix=vtopmart+32pcs+food+storage+container+set%2C+kitchen+%26+pantry+organizers+and+storage%2C+bpa-free+plastic+airtight+food+storage+container+with+lids+for+cer+%2Ckitchen%2C67&sr=1-1",
					EstPrice=79.99,
               Desc="Food Storage Container Set",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/Kettle.jpg",
               SiteUrl="https://www.amazon.ca/Hamilton-Beach-40930C-Electric-Stainless-Kettle/dp/B074T6KZRK/ref=sr_1_4?crid=1P3UZN2T9UUUB&keywords=Hamilton+Beach+Glass+Electric+Tea+Kettle%2C+Water+Boiler+%26+Heater%2C+1+L%2C+Cordless%2C+LED+Indicator%2C+Auto-Shutoff&qid=1673713097&s=kitchen&sprefix=hamilton+beach+glass+electric+tea+kettle%2C+water+boiler+%26+heater%2C+1+l%2C+cordless%2C+led+indicator%2C+auto-shutoff+%2Ckitchen%2C76&sr=1-4",
					EstPrice=49.99,
               Desc="Electric Kettle",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/OvenTrays.jpg",
               SiteUrl="https://www.amazon.ca/Nutrichef-Silicone-Handles-Piece-Black/dp/B09HV2GNYR/ref=sr_1_1?crid=Z2LMTKYNF4X8&keywords=Nutrichef+w%2FHeat+Red+Silicone+Handles%2C+Oven+Safe%2C+6+Piece+Set%2C+Black&qid=1673713178&s=kitchen&sprefix=nutrichef+w%2Fheat+red+silicone+handles%2C+oven+safe%2C+6+piece+set%2C+black+%2Ckitchen%2C84&sr=1-1",
					EstPrice=106.99,
               Desc="Oven Safe Trays, Silicon Handles",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/CordlessVacuum.jpg",
               SiteUrl="https://www.amazon.ca/PRETTYCARE-Cordless-Lightweight-Cost-Effective-W200/dp/B09THNP8V6/ref=sr_1_1?crid=3JR7DJG44T43C&keywords=PRETTYCARE+Cordless+Vacuum+Cleaner+with+LED+Display%2C+6+in+1+Lightweight+Stick+Vacuum+with&qid=1673713243&s=kitchen&sprefix=prettycare+cordless+vacuum+cleaner+with+led+display%2C+6+in+1+lightweight+stick+vacuum+with+%2Ckitchen%2C92&sr=1-1",
					EstPrice=189.99,
               Desc="Cordless Vacuum Cleaner",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/Microwave.jpg",
               SiteUrl="https://www.amazon.ca/Toshiba-EM925A5A-SS-Compact-Microwave-Stainless/dp/B076V72BZ6/ref=sr_1_1?crid=2YN0P9BEUPQNE&keywords=TOSHIBA+ML-+EM25P%28SS%29+Compact+Microwave+with+Sound+on%2FOff+Option%2C+0.9+Cu.ft%2C+Stainless+Steel%2C+EM925A5A-&qid=1673713301&s=kitchen&sprefix=toshiba+ml-+em25p+ss+compact+microwave+with+sound+on%2Foff+option%2C+0+9+cu+ft%2C+stainless+steel%2C+em925a5a-%2Ckitchen%2C59&sr=1-1",
					EstPrice=119.99,
               Desc="Microwave Oven",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/Nightstand.jpg",
               SiteUrl="https://www.ikea.com/ca/en/p/vikhammer-nightstand-black-90388978/",
					EstPrice=129.00,
               Desc="Nightstand",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/Blender.jpg",
               SiteUrl="https://www.amazon.ca/Ninja-BL481C-Nutri-Ninja-Auto-iQ-Blender/dp/B01H8UHB8S/ref=sr_1_1?crid=8UU97ML30IRL&keywords=Ninja+BL481C+Nutri-Ninja+Auto-iQ+Technology+Blender%2C+1000W+%28Canadian+Version&qid=1673713498&s=kitchen&sprefix=ninja+bl481c+nutri-ninja+auto-iq+technology+blender%2C+1000w+canadian+version%2Ckitchen%2C106&sr=1-1",
					EstPrice=129.98,
               Desc="Ninja Blender",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/WinnersMarshallsHomesenseGiftCard.jpg",
               SiteUrl="https://www.giftcards.ca/deal/winners-egift?sscid=11k7_h6kuy&",
					EstPrice=50.00,
               Desc="Winners, Marshalls, and Homesense Gift Card",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/GiantTigerGiftCard.jpg",
               SiteUrl="https://www.gianttiger.com/products/50-giant-tiger-gift-card?variant=40372799930429",
					EstPrice=50.00,
               Desc="Giant Tiger Gift Card",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/DollaramaGiftCard.jpg",
               SiteUrl="https://www.dollarama.com/en-CA/Gift-Cards",
					EstPrice=50.00,
               Desc="Dollarama Gift Card",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/CostcoGiftCard.jpg",
               SiteUrl="https://www.costco.com/costco-shop-card.product.10024438.html",
					EstPrice=50.00,
               Desc="Costco Gift Card",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/IkeaGiftCard.jpg",
               SiteUrl="https://ikeaca.frizbee-solutions.com/home?lang=en_CA",
					EstPrice=50.00,
               Desc="Ikea Gift Card",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/WallmartGiftCard.jpg",
               SiteUrl="https://www.walmart.ca/en/digital-gift-cards?icid=homepage_HP_TopCategory_Giftcards_WM",
					EstPrice=50.00,
               Desc="Wallmart Gift Card",
               Available=true
            },
            new Gift {
               ImgUrl="~/img/thumbnails/AmazonGiftCard.jpg",
               SiteUrl="https://www.amazon.ca/s?i=gift-cards&bbn=9230166011&rh=n%3A9230166011%2Cp_n_format_browse-bin%3A9843162011%2Cp_89%3AAmazon.com.ca%5Cd+Inc.&pf_rd_i=9230166011&pf_rd_m=A1IM4EOPHS76S7&pf_rd_p=2487fb5b-2ac1-48bf-8600-8c4a7535fac0&pf_rd_r=BNPWB45WXFWD02N7SGSC&pf_rd_s=merchandised-search-5&pf_rd_t=101&ref=s9_acss_bw_cg_gclptcg_2b1_w",
					EstPrice=50.00,
               Desc="Amazon Gift Card",
               Available=true
            }
         };
         gifts.ForEach(gift => context.Gifts.Add(gift));
         context.SaveChanges();
      }
   }
}
