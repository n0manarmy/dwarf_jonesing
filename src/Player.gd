extends Node

onready var global_data = get_node("/root/GlobalData")
onready var signals_manager = get_node("/root/SignalsManager")
onready var im = get_node("/root/ItemManager")

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
export var education: Dictionary = {} #Job:classes completed (13 is completed)
export var turn_time_used: int = 0
export var color = Color()
export var rent_extended: int = 0
export var current_money: int = 0
export var player_salary: int = 0
export var possessions: Array = [] #Name:Weath Value

var current_job: Job
var current_rent: int  = 0
var rent_due: int = 0

var debug_this = false

func _ready():
	if debug_this: print(self.name + "._ready")
	signals_manager.connect("change_player_job", self, "change_this_player_job")
	signals_manager.connect("player_data_updated", self, "check_player_changes")
	signals_manager.connect("player_time_up", self, "reset_player")
	signals_manager.connect("on_rest_button_pressed", self, "increase_player_happiness")
	signals_manager.connect("setup_next_player", self, "next_player")
	signals_manager.connect("_on_WorkButton_pressed", self, "work_job")


func _to_string():
	return ".id: {}, work_exp {}, eaten {}, happiness {}, max_happiness {}, wealth {}, max_wealth {}, job {}, max_job {}, education {}, max_education {}, turn_time_used {}, current_job {}, color {}, current_rent {}, rent_due {}, rent_extended {}, possessions {}, current_money {}, player_salary {}".format(
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
			self.print_player_possessions(),
			current_money,
			player_salary
			], "{}")
			

func print_player_possessions():
	var pos_string = "["
	for pos in possessions:
		pos_string += pos.to_string() + ", "
	
	pos_string += "]"
	return pos_string

func reset_player(caller):
	if debug_this: print(self.name, ".reset_player", " caller: ", caller)
	var this_player = global_data.get_current_player()
	
	if this_player.eaten == false:
		this_player.turn_time_used = global_data.TIME_LOSS_NO_FOOD
	else:
		this_player.turn_time_used = 0
		
	# var travel_path_tile_map: TileMap = get_node("/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap")
	# var player_sprite: Sprite = get_node("/root/RootScene/TravelPath/PlayerSprite")
	# signals_manager.emit_signal("player_position_updated", self.name, travel_path_tile_map.map_to_world(player_sprite.START_POS))
	signals_manager.emit_signal("increment_player", self.name)
	signals_manager.emit_signal("player_data_updated", self.name + ".reset_player")


func next_player(caller):
	if debug_this: print(self.name, ".next_player", " caller: ", caller)

	var this_player = global_data.get_current_player()
	this_player.eaten = false

	var player_sprite: Sprite = get_node("/root/RootScene/TravelPath/PlayerSprite")
	var travel_path_tile_map: TileMap = get_node("/root/RootScene/TravelPath/WalkingPath/TravelPathTileMap")
	signals_manager.emit_signal("player_position_updated", self.name, travel_path_tile_map.map_to_world(player_sprite.START_POS))
	player_sprite.modulate = this_player.color
	signals_manager.emit_signal("player_data_updated", self.name + ".next_player")


func increase_player_happiness(caller, values):
	if debug_this: print(self.name + ".increase_player_happiness", values, " caller: ", caller)
	# var value = values[0]
	# var time = values[1]
	# var this_player = self.players[self.current_player - 1]
	var this_player = global_data.get_current_player()
	this_player.happiness_score += values["happiness_increase"]
	this_player.turn_time_used += values["time_used"]
	signals_manager.emit_signal("player_data_updated", self.name)
	
func work_job(caller):
	if debug_this: print(self.name, ".work_job() caller: ", caller)
	var this_player = global_data.get_current_player()
	var time_left = this_player.turn_time_used
	if global_data.WORK_TIME_COST < (global_data.MAX_TIME - time_left):
		this_player.current_money += this_player.player_salary * global_data.WAGE_DAY_MODIFIER
		this_player.turn_time_used = this_player.turn_time_used + global_data.WORK_TIME_COST
	else:
		this_player.current_money += this_player.player_salary * (global_data.MAX_TIME - time_left)
		this_player.turn_time_used = this_player.turn_time_used + global_data.WORK_TIME_COST
	
	this_player.work_exp += global_data.get_rand_between(0,1)
	signals_manager.emit_signal("player_data_updated", self.name)
	

func change_this_player_job(job: Job):
	if debug_this: print(self.name + ".change_this_player_job ", job)
	var this_player = global_data.get_current_player()
#	this_player.current_job = job
	this_player.player_salary = job.base_salary
	global_data.set_current_player_job(job)
	if debug_this: print(self.name, " ", self)
	signals_manager.emit_signal("player_data_updated", self.name)


func check_player_changes(caller):
	if debug_this: print(self.name +".check_player_changes", " caller: ", caller)
	var this_player = global_data.get_current_player()
	
	if this_player.turn_time_used >= global_data.MAX_TIME:
		if debug_this: print(self.name, ".if this_player.turn_time_used >= MAX_TIME:")	
		signals_manager.emit_signal("player_time_up", self.name)
