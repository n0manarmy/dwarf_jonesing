extends Node

onready var signals_manager = get_node("/root/SignalsManager")
onready var im = get_node("/root/InventoryManager")
const Job = preload("res://src/Job.gd")

export var id: int = 0
export var work_exp: int = 0
export var eaten: bool = false
export var happiness_score: int = 0
export var wealth_score: int = 0
export var education_score: int
export var job_score: int = 0
export var max_happiness_score: int = 0
export var max_wealth_score: int = 0
export var max_job_score: int = 0
export var max_education_score: int = 0
var job: Job
export var education: Dictionary = {} #Job:classes completed (13 is completed)
export var turn_time_used: int = 0
export var current_job = "NONE"
export var current_rent:int  = 325
export var rent_due: int = 325
export var color = Color()
export var rent_extended: int = 0
export var possessions: Dictionary = {} #Name:Weath Value

var debug_this = true

# func _init(this_id):
# 	self.id = this_id
# 	self.possessions[im.LOW_COST_APARTMENT.keys()[0]] = im.LOW_COST_APARTMENT.values()[0]

func _ready():
	if debug_this: print(self.name + "._ready")
	signals_manager.connect("player_time_up", self, "player_time_up")

func _to_string():
	return ".id: {}, work_exp {}, eaten {}, happiness {}, max_happiness {}, wealth {}, max_wealth {}, job {}, max_job {}, education {}, max_education {}, turn_time_used {}, current_job {}, color {}, current_rent {}, rent_due {}, rent_extended {}, possessions {},".format(
		[
			id, 
			work_exp, 
			eaten,
			happiness_score,
			max_happiness_score,
			wealth_score,
			max_wealth_score,
			job_score,
			max_job_score, 
			education_score,
			max_education_score,
			turn_time_used,
			current_job,
			color,
			current_rent,
			rent_due,
			rent_extended,
			possessions
			], "{}")
	
func reset_player_new_round():
	self.turn_time_used = 0

func player_time_up():
	var travel_path_tile_map: TileMap = get_node("/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap")
	var player_sprite: Sprite = get_node("/root/RootScene/TravelPath/PlayerSprite")
	signals_manager.emit_signal("player_position_updated", travel_path_tile_map.map_to_world(player_sprite.START_POS))

