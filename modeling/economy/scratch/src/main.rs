
use rand::prelude::*;

fn main() {

}

fn test_econ() {
    const MIN: u32 = 55;
    const MAX: u32 = 155;
    let mut values: Vec<u32> = vec![90, 95, 100, 105, 110];
    let mut rng = rand::thread_rng();


    for _ in 0..100 {
        let min = match values.iter().min() {
            Some(v) => *v,
            None => MIN,
        };
        let max = match values.iter().max() {
            Some(v) => *v,
            None => MAX,
        };
        //dbg!(&min);
        //dbg!(&max);
        let val = if min == max {
            rng.gen_range(MIN..MAX)
        } else {
            rng.gen_range(min..max)
        };

        // println!("{:?}", values);
        println!("{}", val);

        values.push(val);
        values.remove(0);
    }
}

// struct IpAddr {
//     kind: IpAddrKind,
//     address: String,
// }

#[derive(Debug)]
enum IpAddrKind {
    V4(u8, u8, u8, u8),
    V6(String),
}


fn enum_ip_addr() {
    // let home = IpAddr {
    //     kind: IpAddrKind::V4,
    //     address: String::from("192.168.1.1"),
    // };

    // let loopback = IpAddr {
    //     kind: IpAddrKind::V6,
    //     address: String::from("::1"),
    // };

    let loopbackv4 = IpAddrKind::V4(127, 0, 0, 1);
    let loopbackv6 = IpAddrKind::V6(String::from("::1"));

    println!("loopback V4 address: {:?}", loopbackv4);
    println!("looppack V6 address: {:?}", loopbackv6);

}

fn string_slice(s: &String) {
    let s1 = &s[0..4];
    let s3 = &s[..4];
    let s2 = &s[5..s.len()];
    let s4 = &s[5..];
    let s5 = &s[..];
    println!("Strings are {}, {}, {}, {}, and {}", s1, s3, s2, s4, s5)
}

fn slice_string(s: &String) -> usize {
    let bytes = s.as_bytes();
    for (index, &item) in bytes.iter().enumerate() {
        if item == b' ' {
            return index;
        }
    }
    return s.len()
}

fn get_string_length(s: &String) -> usize {
    s.len()
}

fn math_scratch() {
    let x: u32 = 5;
    println!("x value is {}", x);
    let x = x + 1;
    println!("x value is {}", x);
    let x = x * x;
    println!("x value is {}", x);        
}

fn string_scratch() {
    let s = String::from("This is a ");
    println!("{}", s);
    let t = s.clone()   ;
    println!("{}", s);
    println!("{}", t);
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_test_econ() {
        test_econ();
    }
    

    #[test]
    fn test_enum_ip_addr() {
        enum_ip_addr()
    }

    #[test]
    fn test_math_scratch() {
        math_scratch()
    }

    #[test]
    fn test_string_scratch() {
        string_scratch()
    }

    #[test]
    fn test_get_string_length() {
        let s = String::from("Rust Scratch!");
        let size = get_string_length(&s);
        println!("String size for \"{}\" is {}", s, size)
    }

    #[test]
    fn test_slice_string() {
        let s = String::from("Rust Scratch!");
        let spce = slice_string(&s);
        println!("The space for {} is at pos {}", s, spce)
    }

    #[test]
    fn test_string_slice() {
        let s = String::from("Rust Scratch!");
        string_slice(&s);
    }
}