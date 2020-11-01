import random
import numpy as np

num_samples = 250
theta = np.linspace(0, 2*np.pi, num_samples)

# cocor
LAT = (44.45354650588408 + 44.40917197103038)/2
LNG = (26.1433499764352 + 26.06472907443683)/2

# bloc
#LAT = 44.383061735459485
#LNG = 26.10818481433853

f = open(".\SeedData\Temperatures.json", "w")

f.write("[\n")

for t in theta:

    r = random.uniform(0.002, 0.015)
    x = r * np.cos(t) + LAT
    y = r * np.sin(t) + LNG
    count = random.uniform(22, 25)

    strn = "{\n  \"lat\": " + str(x) + ",\n  \"lng\": " + str(y) + \
        ",\n  \"count\": " + str(count) + "\n}, " + "\n"
    f.write(strn)

strn = "{\n  \"lat\": " + str(0) + ",\n  \"lng\": " + str(0) + \
    ",\n  \"count\": " + str(count) + "\n}" + "\n"
f.write(strn)
f.write("\n]")

f.close()
