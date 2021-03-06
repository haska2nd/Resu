//css_reference C:\V7.7.1.dll;
// https://github.com/User5981/Resu
// Unscathed Monster Shower plugin for TurboHUD version 28/10/2018 02:13
using Turbo.Plugins.Default;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Turbo.Plugins.Resu
{

    public class UnscathedMonsterShowerPlugin : BasePlugin, IInGameWorldPainter
    {
        public static HashSet<string> DangerousMonsters = new HashSet<string>() {"Wood Wraith", "Highland Walker", "The Old Man", "Fallen Lunatic", "Deranged Fallen", "Fallen Maniac", "Frenzied Lunatic", "Herald of Pestilence", "Terror Demon", "Demented Fallen", "Savage Beast", "Tusked Bogan", "Punisher", "Anarch", "Corrupted Angel", "Winged Assassin", "Exarch"};
        
        public UnscathedMonsterShowerPlugin()
        {
            Enabled = true;
        }
        
        public override void Load(IController hud)
        {
            base.Load(hud);
            
            
        }
        
        public void PaintWorld(WorldLayer layer)
        {
         double MyMaxWeaponRange = 130D;
         var UnscathedMonsters = Hud.Game.AliveMonsters.Where(x => x.Rarity == ActorRarity.Normal && !x.Untargetable && !x.Invisible && x.NormalizedXyDistanceToMe < MyMaxWeaponRange); //&& !DangerousMonsters.Contains(x.SnoActor.NameEnglish) 
         var CatEye = Hud.Texture.GetTexture(2789104100);
         var BlueEye = Hud.Texture.GetTexture(1423609272);
         var RedEye = Hud.Texture.GetTexture(2189544651);
         var BlackEye = Hud.Texture.GetTexture(3379382182);
         var Eye = Hud.Texture.GetTexture(2789104100);
         
         foreach (var UnscathedMonster in UnscathedMonsters)
         {
          var ScreenCoor = UnscathedMonster.FloorCoordinate.Offset(0, 0, (UnscathedMonster.RadiusScaled*3)).ToScreenCoordinate();
          float Size = (float)((UnscathedMonster.CurHealth/UnscathedMonster.MaxHealth*100)/10);
          
          if (UnscathedMonster.SnoActor.Sno % 5 == 0) Eye = RedEye;
          else if (UnscathedMonster.SnoActor.Sno % 3 == 0) Eye = BlueEye;
          else Eye = CatEye;
              
            if ((UnscathedMonster.AcdId + (Hud.Time.Now.Millisecond/2)) % 40 == 0){}
            else if ((UnscathedMonster.AcdId + (Hud.Time.Now.Millisecond/2)) % 99 == 0) 
             {
             Eye.Draw(ScreenCoor.X-5, ScreenCoor.Y, 10,Size, 1f);
             }
            else if ((UnscathedMonster.AcdId + (Hud.Time.Now.Millisecond/2)) % 111 == 0) 
             {
             Eye.Draw(ScreenCoor.X+5, ScreenCoor.Y, 10, Size, 1f);
             }
            else
             {
              Eye.Draw(ScreenCoor.X-5, ScreenCoor.Y, 10, Size, 1f);
              Eye.Draw(ScreenCoor.X+5, ScreenCoor.Y, 10, Size, 1f);
             }
         }
        
        }

    }

}