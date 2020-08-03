# PayParking

## Usage

The application runs in REPL mode, i.e. it waits for a command,
interprets it once given, then and waits for the next command.

To enter the parking garage with a car having the registration `B10ABC`:

```
enter B10ABC
```

To leave the parking garage with a car having the registration `B10ABC`:

```
leave B10ABC
```

A report will be printed on leaving, containing the time spent and amount paid.

To print a report of all the cars in the garage:

```
list
```

To print the price of using the garage:

```
price
```

To quit the application:

```
quit
```


## Run Example

```
Welcome to PayParking!
Commands: enter <registration>, leave <registration>, list, quit
Waiting for user input...
price
First hour: 10 lei :: Each hour past the first: 5 lei
Waiting for user input...
enter B10ABC
Entry succeeded.
Waiting for user input...
enter B20KLM
Entry succeeded.
Waiting for user input...
enter B30XYZ
Entry succeeded.
Waiting for user input...
list
B10ABC :: Spent 00h:00m:31s :: Owes 10 lei
B20KLM :: Spent 00h:00m:27s :: Owes 10 lei
B30XYZ :: Spent 00h:00m:01s :: Owes 10 lei
Waiting for user input...
enter B30XYZ
Entry failed, car with registration B30XYZ already in garage.
Waiting for user input...
leave B30XYZ
Car with registration B30XYZ left after 00h:00m:17s, paid 10 lei.
Waiting for user input...
leave B30XYZ
Leave failed, car with registration B30XYZ not found in garage.
Waiting for user input...
list
B10ABC :: Spent 00h:01m:04s :: Owes 10 lei
B20KLM :: Spent 00h:01m:00s :: Owes 10 lei
Waiting for user input...
quit
Thank you for using PayParking. Exiting...
```
