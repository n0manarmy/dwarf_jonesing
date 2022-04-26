extends Node2D

# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var MAX_TIME = 1500
var WORK_JOB_COST = 9.5
var WORK_JOB_MULTIPLYER = 8
# var BASE_WORK_TIME = 50


# ECONOMY
var base_econ_value = 1
var ECON_MIN = 55
var ECON_MAX = 155
var econ_values = [90, 95, 100, 105, 110]

var base_starting_difficulty = 50
var button_clicked_add_time = 10
var game_rounds = 0
var current_player = 1
var player_count = 1
var players = []
var jobs = []

var rng = RandomNumberGenerator.new()

onready var player_count_select_scene = get_node_or_null("/root/RootScene/PlayerCountSelectScene")
onready var start_values_scene = get_node_or_null("/root/RootScene/StartValuesScene")
onready var debug_scene = get_node_or_null("/root/RootScene/DebugScene")
onready var signals_manager = get_node_or_null("/root/SignalsManager")
onready var job_manager = get_node("/root/JobManager")
onready var im = get_node("/root/InventoryManager")
onready var scene_01_node = get_node_or_null("/root/RootScene/TravelPath/InfoScene/Scene01")

const Player = preload("res://src/Player.gd")

var debug_this = true

# new Degree(00, "None", 0),
# new Degree(01, "Junior College", 10),
# new Degree(02, "Trade School", 10),
# new Degree(03, "Business Administration", 10),
# new Degree(04, "Electronics", 10),
# new Degree(05, "Pre-Engineering", 10),
# new Degree(06, "Engineering", 10),
# new Degree(07, "Academic", 10),
# new Degree(08, "Grad School", 10),
# new Degree(09, "Post Doctoral", 10),
# new Degree(10, "Research", 10),
# new Degree(11, "Publishing", 10),

# Called when the node enters the scene tree for the first time.
func _ready():
	if debug_this: print(self.name + "._ready")

	rng.seed = hash(OS.get_datetime())
	
	signals_manager.connect("player_count_selected", self, "setup_players")
	signals_manager.connect("player_time_up", self, "next_player")
	signals_manager.connect("increment_player", self, "increment_current_player")
		
	if start_values_scene != null:
		if debug_this: print(self.name + ".if start_values_scene != null:")
		# signals_manager.connect("increment_players", self, "increment_current_player")
		signals_manager.connect("goals_values_done", self, "set_player_max_values")
		signals_manager.connect("reset_players", self, "reset_players")
			
	setup_players(self.name, player_count)
	setup_jobs()
	setup_board()
	adjust_economy()


func get_rand_between(_min: int, _max: int):
	return rng.randi_range(_min, _max)
	

func adjust_for_economy(val):
	# var debug_this = false

	if debug_this: print(self.name + ".adjust_for_economy")
	var adjusted = (self.econ_values.back() as float / 100 as float)
	if debug_this: print(self.name + ".adjusted: ", adjusted as float)
	return (val * adjusted) as int
	

func adjust_economy():
	# var debug_this = false
	if debug_this: print(self.name +".adjust_economy")
	
	var list_min = econ_values.min()
	var list_max = econ_values.max()
	# if debug_this: print(self.name + ".list_min: ", list_min)
	# if debug_this: print(self.name + ".list_max: ", list_max)

	var list_avg = 0
	for v in econ_values:
		list_avg += v
	list_avg = list_avg / econ_values.size()

	if list_min == list_max:
		var val = (rng.randi_range(ECON_MIN, ECON_MAX) + list_avg) / 2
		econ_values.append(val)
	else:
		var val = (rng.randi_range(list_min, list_max) + list_avg) / 2
		econ_values.append(val)		

	econ_values.remove(0)
	signals_manager.emit_signal("update_job_economy", self.name)
	# if debug_this: print(self.name + "econ_values: ", econ_values)


func next_player(caller):
	if debug_this: print(self.name + ".next_player()", " caller: ", caller)

	var this_player = self.get_current_player()
	signals_manager.emit_signal("disable_location_buttons", self.name, false)

	if this_player == self.players[0]:
		self.game_rounds += 1
		signals_manager.emit_signal("update_job_economy", self.name)
	
	signals_manager.emit_signal("player_data_updated", self.name)
		

func increment_current_player(caller):
	if debug_this: print(self.name + ".increment_current_player()", " caller: ", caller)
	if current_player == player_count:
		current_player = 1
	else:
		current_player += 1

	signals_manager.emit_signal("setup_next_player", self.name)
	signals_manager.emit_signal("player_data_updated", self.name)


func reset_players(caller):
	if debug_this: print(self.name + ".reset_players()", " caller: ", caller)
	current_player = 1


func get_current_player():
	# if debug_this: print(self.name + ".get_current_player()")
	# if debug_this: print(self.name + ".current_player: ", self.current_player)
	return self.players[self.current_player - 1]


func setup_board():
	self.game_rounds = 1
	signals_manager.emit_signal("global_data_updated", self.name)


func setup_jobs():
	if debug_this: print(self.name + ".setup_jobs: ")


func setup_players(caller, val):
	if debug_this: print(self.name + "._setup_players: ", val, " caller: ", caller)
	player_count = val
	players.clear()

	var transparency: float = 1.0
	
	for x in player_count as int:
		print(self.name + ".creating player ", x + 1)
		# var player = Player.duplicate()
		var player = Player.new()
		player.possessions[im.LOW_COST_APARTMENT.keys()[0]] = im.LOW_COST_APARTMENT.values()[0]
		player.education["None"] = 99
		player.id = x + 1
		player.current_job = job_manager.jobs[0]
		match (x + 1):
			1:
				if debug_this: print(self.name + ".player 1 coloring")
#				player.get_child(0).modulate = Color(200, 0, 0)
				player.color = Color(200,0,0,transparency)
			2: 
				if debug_this: print(self.name + ".player 2 coloring")				
#				player.get_child(0).modulate = Color(0, 200, 0)
				player.color = Color(0,200,0,transparency)				
			3: 
				if debug_this: print(self.name + ".player 3 coloring")				
#				player.get_child(0).modulate = Color(0, 0, 200)
				player.color = Color(0,0,200,transparency)
			4: 
				if debug_this: print(self.name + ".player 4 coloring")				
#				player.get_child(0).modulate = Color(100, 0, 100)
				player.color = Color(100,0,100,transparency)				
				
		players.append(player)
	
	for player in players:
		if debug_this: print(self.name + ".player id: ", player.id)
		if debug_this: print(self.name + ".player.to_string(): ", player.to_string())

	if debug_this: print(self.name + ".current_player ", current_player)
	self.reset_players(self.name)
	signals_manager.emit_signal("player_data_updated", self.name)


func set_player_max_values(values):
	if debug_this: print(self.name + ".set_player_max_values(values)", values)
	self.get_current_player().max_job_score = values["max_job"]
	self.get_current_player().max_education_score = values["max_education"]
	self.get_current_player().max_happiness_score = values["max_happiness"]
	self.get_current_player().max_wealth_score = values["max_wealth"]
	self.get_current_player().to_string()

	signals_manager.emit_signal("player_data_updated", self.name)
