# Better914
## A brand new item upgrade system
From now on, items are upgraded according to levels from -4 to +4<br>
Each level has a specific chance of occur<br>
| Level | Chances | SCP-914 knob position |
|:-------:|:----------:|:--------------:|
| -4 | 5% | Rough |
| -3 | 10% | Rough |
| -2 | 100% / 20% | Rough / Coarse |
| -1 | 100% | Coarse |
| 0 | 100% | 1:1 |
| 1 | 100% | Fine |
| 2 | 20% / 100% | Fine / VeryFine |
| 3 | 10% | VeryFine |
| 4 | 5% | VeryFine |

In addition, levels -1 to 1 have 20% chances of failure - (upgrade to the same item)<br>
Levels -2 to 2 are equivalent to the knob settings (`-2 - Rough`, `-1 - Coarse` etc.)<br>
<br>
This system gives you the chance to upgrade a scientist's card to O5 in two upgrades with the risk of burning the card (tested)<br>

## Modification of the player's life<br>
On each setting there is a chance (depending on the setting of the knob) for permanent¹ adding or taking life from the player.<br>
| SCP-914 knob position | Ammount | Chances |
|:---------:|:-------:|:-------:|
| Rough | -100%² ³ ⁴ | 60% |
| Coarse | -50%² ³ ⁴ | 50% |
| 1:1 | +0%² ³ | 100% |
| Fine | +50%² ³ | 40% |
| VeryFine | +100%² ³ | 30% |

¹ - until death - if the player has a `-50%` life, then the first aid kit will regenerate only to this value. Even escaping doesn't help. To get rid of this effect, use SCP-914 or die.<br>
² - % of basic life (not actual life)<br>
³ - It also affects zombies<br>
⁴ - For SCP (except SCP-049-2), the percentage points are divided in half (see `b914_SCP_Damage_chance_multiplier`)<br>

# Configs
| Config Option | Value Type | Default Value | Description |
|:-----------------------:|:----------:|:------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------:|:----------------------------------------------------------------------------------------------------------------------:|
| b914_enabled | boolean | true | Enables/Disables this plugin |
| b914_knob_while_working | boolean | true | Enables/Disables option to rotate knob while SCP-914 is working |
| b914_override_handcuff_config | boolean | true | Indicates if `b914_disarmed_interact` sould be used instread of game value |
| b914_disarmed_interact | boolean | true | Enables/Disables ability of disarmed people to interact with SCP-914 |
| b914_use_new_recipe_system | boolean | true | Enables/Disables ussage of new recipes |
| b914_level-4_chance | float | 5.0 | Chances to degrade item to level -4 |
| b914_level-3_chance | float | 10.0 | Chances to degrade item to level -3 |
| b914_level-2_chance | float | 20.0 | Chances to degrade item to level -2 |
| b914_level2_chance | float | 20.0 | Chances to upgrade item to level 2 |
| b914_level3_chance | float | 10.0 | Chances to upgrade item to level 3 |
| b914_level4_chance | float | 5.0 | Chances to upgrade item to level 4 |
| b914_same_item_chance | float | 20.0 | Chances for upgrade to not occure on `coarse`, `1:1` and `fine` settings |
| b914_inv_upgrade_chance | float | 20.0 | Chances for upgrade one random item in player inventory while inside SCP-914 |
| b914_change_player_health | boolean | true | Enables/Disables modification of health by SCP-914 |
| b914_rough_damage_chance | float | 60.0 | Chances for taking health from player |
| b914_coarse_damage_chance | float | 50.0 | Chances for taking health from player |
| b914_fine_heal_chance | float | 40.0 | Chances for giving health to player |
| b914_veryfine_heal_chance | float | 30.0 | Chances for giving health to player |
| b914_rough_damage_amount | float | 100.0 | % Ammount of health to take from player |
| b914_coarse_damage_amount | float | 50.0 | % Ammount of health to take from player |
| b914_fine_heal_amount | float | 25.0 | % Ammount of health to give to player |
| b914_veryfine_heal_amount | float | 50.0 | % Ammount of health to give to player |
| b914_rough_coarse_damage_SCPs | boolean | true | Enables/Disables taking damage to SCP's inside SCP-914 while on settings `rough` or `coarse` |
| b914_SCP_Damage_chance_multiplier | float | 0.5 | Multiplies chances of taking damage by SCP's (see `b914_rough_damage_chance` and `b914_coarse_damage_chance` |
| b914_swap_players_roles | boolean | true | Enables/Disables swapping of players roles while on setting `1:1` *(To occur two different classes inside SCP-914 are needed)* |
| b914_swap_role_chance | float | 20.0 | Chances for swapping roles to occur |
