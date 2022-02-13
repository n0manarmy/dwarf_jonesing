extends Node2D

export var id: int = 0
export var work_exp: int = 0
export var eaten: bool = false
export var happiness: int = 0
export var max_happiness: int = 0
export var wealth: int = 0
export var max_wealth: int = 0
export var job: int = 0
export var max_job: int = 0
export var education: int = 0
export var max_education: int = 0
export var turn_time_used: int = 0
export var current_job = "Needs fixing"
export var color = Color()

var debug_this = true

func _ready():
	if debug_this: print(self.name + "._ready")

func to_string():
	print(self.name + ".id: ", id)
	print(self.name + ".work_exp ", work_exp)
	print(self.name + ".eaten ", eaten)
	print(self.name + ".happiness ", happiness)
	print(self.name + ".max_happiness ", max_happiness)
	print(self.name + ".wealth ", wealth)
	print(self.name + ".max_wealth ", max_wealth)
	print(self.name + ".job ", job)
	print(self.name + ".max_job ", max_job)
	print(self.name + ".education ", education)
	print(self.name + ".max_education ", max_education)
	print(self.name + ".turn_time_used ", turn_time_used)
	print(self.name + ".current_job ", current_job)
	print(self.name + ".color ", color)

# Called every frame. 'delta' is the elapsed time since the previous frame.
#func _process(delta):
#	pass
