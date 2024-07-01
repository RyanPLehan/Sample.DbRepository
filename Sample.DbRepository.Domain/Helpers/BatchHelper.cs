using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sample.DbRepository.Domain.Asserts;

namespace Sample.DbRepository.Domain.Helpers
{
    /// <summary>
    /// This will assist in dealing with large quantities by batching
    /// </summary>
    public static class BatchHelper
    {
        private const int MIN_BATCH_SIZE = 1;

        public const int MIN_SKIP = 0;
        public const int MIN_TAKE = 1;
        public const int MAX_TAKE = 100;


        public static int ApplySkip(int skip) => Math.Max(MIN_SKIP, skip);
        public static int ApplyTake(int take) => Math.Min(Math.Max(MIN_TAKE, take), MAX_TAKE);



        public static void Batch<TValue>(int batchSize,
                                         IEnumerable<TValue> values, 
                                         Action<IEnumerable<TValue>> function)
        {
            Argument.AssertNotNull(values, nameof(values));
            Argument.AssertNotDelegate(function, nameof(function));
            Argument.AssertNotLessThan<int>(batchSize, MIN_BATCH_SIZE);

            int skip = 0;
            int count = values.Count();
            while (skip < count)
            {
                IEnumerable<TValue> batchValues = values.Skip(skip)
                                                        .Take(batchSize)
                                                        .ToArray();
                // Hand off to delegate
                function(batchValues);

                // Update the skip count.  ok to use BATCH_SIZE, because .Take will take max of value or less
                skip += batchSize;
            }
        }


        public static async Task BatchAsync<TValue>(int batchSize,
                                                    IEnumerable<TValue> values,
                                                    Func<IEnumerable<TValue>, Task> function)
        {
            Argument.AssertNotNull(values, nameof(values));
            Argument.AssertNotDelegate(function, nameof(function));
            Argument.AssertNotLessThan<int>(batchSize, MIN_BATCH_SIZE);

            int skip = 0;
            int count = values.Count();
            while (skip < count)
            {
                IEnumerable<TValue> batchValues = values.Skip(skip)
                                                        .Take(batchSize)
                                                        .ToArray();
                // Hand off to delegate
                await function(batchValues);

                // Update the skip count.  ok to use BATCH_SIZE, because .Take will take max of value or less
                skip += batchSize;
            }
        }



        public static IEnumerable<TResult> Batch<TValue, TResult>(int batchSize,
                                                                  IEnumerable<TValue> values,
                                                                  Func<IEnumerable<TValue>, TResult> function)
        {
            Argument.AssertNotNull(values, nameof(values));
            Argument.AssertNotDelegate(function, nameof(function));
            Argument.AssertNotLessThan<int>(batchSize, MIN_BATCH_SIZE);

            int skip = 0;
            int count = values.Count();
            List<TResult> results = new List<TResult>();

            while (skip < count)
            {
                IEnumerable<TValue> batchValues = values.Skip(skip)
                                                        .Take(batchSize)
                                                        .ToArray();
                // Hand off to delegate
                TResult result = function(batchValues);
                results.Add(result);

                // Update the skip count.  ok to use BATCH_SIZE, because .Take will take max of value or less
                skip += batchSize;
            }

            return results;
        }


        public static async Task<IEnumerable<TResult>> BatchAsync<TValue, TResult>(int batchSize,
                                                                                   IEnumerable<TValue> values,
                                                                                   Func<IEnumerable<TValue>, Task<TResult>> function)
        {
            Argument.AssertNotNull(values, nameof(values));
            Argument.AssertNotDelegate(function, nameof(function));
            Argument.AssertNotLessThan<int>(batchSize, MIN_BATCH_SIZE);

            int skip = 0;
            int count = values.Count();
            List<TResult> results = new List<TResult>();

            while (skip < count)
            {
                IEnumerable<TValue> batchValues = values.Skip(skip)
                                                        .Take(batchSize)
                                                        .ToArray();
                // Hand off to delegate
                TResult result = await function(batchValues);
                results.Add(result);

                // Update the skip count.  ok to use BATCH_SIZE, because .Take will take max of value or less
                skip += batchSize;
            }

            return results;
        }


        public static IEnumerable<TResult> Batch<TValue, TResult>(int batchSize,
                                                                  IEnumerable<TValue> values,
                                                                  Func<IEnumerable<TValue>, IEnumerable<TResult>> function)
        {
            Argument.AssertNotNull(values, nameof(values));
            Argument.AssertNotDelegate(function, nameof(function));
            Argument.AssertNotLessThan<int>(batchSize, MIN_BATCH_SIZE);

            int skip = 0;
            int count = values.Count();
            List<TResult> results = new List<TResult>();

            while (skip < count)
            {
                IEnumerable<TValue> batchValues = values.Skip(skip)
                                                        .Take(batchSize)
                                                        .ToArray();
                // Hand off to delegate
                IEnumerable<TResult> result = function(batchValues);
                results.AddRange(result);

                // Update the skip count.  ok to use BATCH_SIZE, because .Take will take max of value or less
                skip += batchSize;
            }

            return results;
        }


        public static async Task<IEnumerable<TResult>> BatchAsync<TValue, TResult>(int batchSize,
                                                                                   IEnumerable<TValue> values,
                                                                                   Func<IEnumerable<TValue>, Task<IEnumerable<TResult>>> function)
        {
            Argument.AssertNotNull(values, nameof(values));
            Argument.AssertNotDelegate(function, nameof(function));
            Argument.AssertNotLessThan<int>(batchSize, MIN_BATCH_SIZE);

            int skip = 0;
            int count = values.Count();
            List<TResult> results = new List<TResult>();

            while (skip < count)
            {
                IEnumerable<TValue> batchValues = values.Skip(skip)
                                                        .Take(batchSize)
                                                        .ToArray();
                // Hand off to delegate
                IEnumerable<TResult> result = await function(batchValues);
                results.AddRange(result);

                // Update the skip count.  ok to use BATCH_SIZE, because .Take will take max of value or less
                skip += batchSize;
            }

            return results;
        }
    }
}
