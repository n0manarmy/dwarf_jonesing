extends Object

export var pos: int
export var scene: String
export var company: String
export var job_name: String
export var base_salary: int
export var required_degrees: Array
export var required_work_exp: int
export var job_available: bool

var debug_this = true

func _init(_pos, _scene, _company, _job_name, _base_salary, _required_degrees, _required_work_exp, _job_available):
	self.pos = _pos
	self.scene = _scene
	self.company = _company
	self.job_name = _job_name
	self.base_salary = _base_salary
	self.required_degrees = _required_degrees
	self.required_work_exp = _required_work_exp
	self.job_available = _job_available


func _ready():
	if debug_this: print(self.name + "._ready")
	pass

func to_string():
	print("Pos: ", self.pos)
	print("Scene: ", self.scene)
	print("Company: ", self.company)
	print("Job Name: ", self.job_name)
	print("Base Salary: ", self.base_salary)
	print("Required Degrees: ", self.required_degrees)
	print("Required Work Exp: ", self.required_work_exp)
	print("Job Available: ", self.job_available)
