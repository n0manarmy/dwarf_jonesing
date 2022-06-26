
use rand::prelude::*;

fn main() {

}

fn test_econ() {
    const MIN: u32 = 55;
    const MAX: u32 = 155;
    let mut rng = rand::thread_rng();

    let ending: Vec<u32> = Vec::new();

    for _ in 0..100 {
        let mut values: Vec<u32> = vec![90, 95, 100, 105, 110];
        let mut overall_avg = 0;

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

            let avg = values.iter().sum::<u32>() / 5;
            let val = (val + avg) / 2;
            // println!("{:?}", values);
            // println!("{}", val);

            if overall_avg == 0 {
                overall_avg = val
            } else {
                overall_avg = (overall_avg + val) / 2;
            }

            values.push(val);
            values.remove(0);
        }

        println!("{}", overall_avg)

    }
}

#[cfg(test)]
mod tests {
    use super::*;

    #[test]
    fn test_test_econ() {
        test_econ();
    }
}