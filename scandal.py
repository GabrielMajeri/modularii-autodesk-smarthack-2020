import random
import numpy as np

num_samples = 500
theta = np.linspace(0, 2*np.pi, num_samples)

LAT = (44.45354650588408 + 44.40917197103038)/2
LNG = (26.1433499764352 + 26.06472907443683)/2


LAT = 44.383061735459485
LNG = 26.10818481433853

for t in theta:
    lat = random.uniform(44.45354650588408, 44.40917197103038)
    lng = random.uniform(26.1433499764352, 26.06472907443683)

    r = random.uniform(0.002, 0.015)
    x = r * np.cos(t) + LAT
    y = r * np.sin(t) + LNG
    count = random.uniform(19, 27)
    print("{lat:", x, ", lng:", y, ", count:", count, "}, ")
