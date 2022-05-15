import sys
import numpy as np
import random
import matplotlib

matplotlib.use("Qt5Agg")
import matplotlib.pyplot as plt


def random_color():
    c1 = random.randint(0, 255)
    c2 = random.randint(0, 255)
    c3 = random.randint(0, 255)
    return "#%02x%02x%02x" % (c1, c2, c3)


if __name__ == "__main__":
    args = sys.argv
    files = [args[1], args[2], args[3]]
    no_exp = int(files[0].split("-")[1][0])
    exp_data = np.array(
        [np.genfromtxt(file, delimiter="|", skip_header=1) for file in files]
    )
    # colors = [random_color(), random_color(), random_color(), random_color()]
    colors = [["blue", "orange"], ["red", "green"]]
    labels = [
        ["BestFitness", "AverageFitnessPopulation"],
        ["BestMaxDistance", "BestMaxDistanceTime"],
    ]
    # titles = ["Fitness", "Distance(normalized)"]
    cols = [[1, 2], [3, 4]]

    plt.figure()
    plt.suptitle("Fitness and Distance (normalized)")
    for i in range(len(cols)):
        plt.subplot(2, 1, i + 1)
        # plt.title(titles[i])
        for j in range(len(cols[i])):
            arr = exp_data[:, :, cols[i][j]]
            mn = arr.mean(axis=0)  # sum(arr) / len(arr)
            mx = np.max(mn)
            if i == 1:
                mn /= mx
                plt.xlabel("No. of generations")
            plt.plot(mn, color=colors[i][j], marker=".", label=labels[i][j])
        plt.legend()
        plt.show(block=False)

    plt.savefig(f"exp{no_exp}.png")
